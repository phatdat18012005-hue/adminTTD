using adminTTD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace adminTTD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Dang nhap nguoi dung
        /// </summary>
        /// <param name="loginRequest">Email va mat khau</param>
        /// <returns>Thong tin nguoi dung neu dang nhap thanh cong</returns>
        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.MatKhau))
            {
                return BadRequest(new LoginResponse
                {
                    Success = false,
                    Message = "Email va mat khau khong duoc de trong"
                });
            }

            var user = _context.NguoiDung.FirstOrDefault(u => u.Email == loginRequest.Email);

            if (user == null)
            {
                return Unauthorized(new LoginResponse
                {
                    Success = false,
                    Message = "Email hoac mat khau khong chinh xac"
                });
            }

            if (string.IsNullOrEmpty(user.MatKhau) || !VerifyPassword(loginRequest.MatKhau, user.MatKhau))
            {
                return Unauthorized(new LoginResponse
                {
                    Success = false,
                    Message = "Email hoac mat khau khong chinh xac"
                });
            }

            var role = NormalizeRole(user.VaiTro);
            var token = GenerateJwtToken(user, role);

            return Ok(new LoginResponse
            {
                Success = true,
                Message = "Dang nhap thanh cong",
                Token = token,
                User = new NguoiDung
                {
                    Id = user.Id,
                    Ten = user.Ten,
                    Email = user.Email,
                    VaiTro = role
                }
            });
        }

        /// <summary>
        /// Dang ky tai khoan moi
        /// </summary>
        /// <param name="registerRequest">Email va mat khau</param>
        /// <returns>Thong tin tai khoan da tao</returns>
        [HttpPost("register")]
        public ActionResult<LoginResponse> Register([FromBody] LoginRequest registerRequest)
        {
            if (registerRequest == null || string.IsNullOrEmpty(registerRequest.Email) || string.IsNullOrEmpty(registerRequest.MatKhau))
            {
                return BadRequest(new LoginResponse
                {
                    Success = false,
                    Message = "Email va mat khau khong duoc de trong"
                });
            }

            var existingUser = _context.NguoiDung.FirstOrDefault(u => u.Email == registerRequest.Email);
            if (existingUser != null)
            {
                return BadRequest(new LoginResponse
                {
                    Success = false,
                    Message = "Email da duoc su dung"
                });
            }

            var newUser = new NguoiDung
            {
                Email = registerRequest.Email,
                MatKhau = HashPassword(registerRequest.MatKhau),
                VaiTro = "user"
            };

            _context.NguoiDung.Add(newUser);
            _context.SaveChanges();

            return Ok(new LoginResponse
            {
                Success = true,
                Message = "Dang ky thanh cong",
                User = new NguoiDung
                {
                    Id = newUser.Id,
                    Email = newUser.Email,
                    VaiTro = newUser.VaiTro
                }
            });
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                Id = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Email = User.FindFirstValue(ClaimTypes.Email),
                VaiTro = User.FindFirstValue(ClaimTypes.Role)
            });
        }

        private string GenerateJwtToken(NguoiDung user, string role)
        {
            var key = _configuration["Jwt:Key"] ?? "THIS_IS_A_TEMP_DEV_KEY_CHANGE_ME_2026";
            var expireHours = int.TryParse(_configuration["Jwt:ExpireHours"], out var hours) ? hours : 8;
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email ?? string.Empty),
                new(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expireHours),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string NormalizeRole(string? role)
        {
            if (string.IsNullOrWhiteSpace(role)) return "user";
            return role.Trim().ToLowerInvariant();
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrEmpty(hash))
                return false;

            var hashOfInput = HashPassword(password);
            return hashOfInput == hash;
        }
    }
}
