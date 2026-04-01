using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace adminTTD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BaiVietController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lay danh sach tat ca bai viet
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.BaiViet.ToListAsync();
            return Ok(data);
        }

        /// <summary>
        /// Lay bai viet theo ID
        /// </summary>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.BaiViet.FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        /// <summary>
        /// Tao bai viet moi
        /// </summary>
        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> Create(BaiViet model)
        {
            model.NgayTao = DateTime.Now;
            _context.BaiViet.Add(model);
            await _context.SaveChangesAsync();
            return Ok(model);
        }

        /// <summary>
        /// Cap nhat bai viet
        /// </summary>
        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BaiViet model)
        {
            var item = await _context.BaiViet.FindAsync(id);
            if (item == null) return NotFound();

            item.TieuDe = model.TieuDe;
            item.NoiDung = model.NoiDung;
            item.TrangThai = model.TrangThai;

            await _context.SaveChangesAsync();
            return Ok(item);
        }

        /// <summary>
        /// Xoa bai viet
        /// </summary>
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.BaiViet.FindAsync(id);
            if (item == null) return NotFound();

            _context.BaiViet.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
