# AuthController - Huong Dan Su Dung

## Mo Ta

AuthController la mot REST API controller xu ly xac thuc nguoi dung:
- **Dang Nhap** - Xac minh email va mat khau
- **Dang Ky** - Tao tai khoan nguoi dung moi
- **Bao Mat** - Ma hoa mat khau bang SHA256

## API Endpoints

### 1. Dang Nhap
**POST** `/api/auth/login`

**Request:**
```json
{
    "email": "user@example.com",
    "matKhau": "password123"
}
```

**Response (200 OK):**
```json
{
    "success": true,
    "message": "Dang nhap thanh cong",
    "user": {
        "id": 1,
        "ten": "John Doe",
        "email": "user@example.com",
        "vaiTro": "admin"
    }
}
```

**Response (401 Unauthorized):**
```json
{
    "success": false,
    "message": "Email hoac mat khau khong chinh xac"
}
```

---

### 2. Dang Ky
**POST** `/api/auth/register`

**Request:**
```json
{
    "email": "newuser@example.com",
    "matKhau": "password123"
}
```

**Response (200 OK):**
```json
{
    "success": true,
    "message": "Dang ky thanh cong",
    "user": {
        "id": 2,
        "email": "newuser@example.com",
        "vaiTro": "user"
    }
}
```

**Response (400 Bad Request):**
```json
{
    "success": false,
    "message": "Email da duoc su dung"
}
```

---

## Cau Truc Du An

```
adminTTD/
??? Controllers/
?   ??? AuthController.cs          # Xu ly dang nhap/dang ky
?   ??? BaiVietController.cs       # Xu ly bai viet
??? Models/
?   ??? LoginRequest.cs            # Model yeu cau
?   ??? LoginResponse.cs           # Model phan hoi
??? Migrations/
?   ??? 20260326085546_InitDB.cs
?   ??? 20260330005751_InitFullDatabase.cs
??? AppDbContext.cs                # Database context
??? Program.cs                     # Cau hinh ung dung
??? wwwroot/
?   ??? login.html                # Trang dang nhap
??? test-auth.http                # File test API
```

---

## Cach Su Dung

### 1. Tren Trang Web
```
https://localhost:7047/login.html
```
- Nhap email va mat khau
- Click "Dang Nhap" hoac "Dang Ky"
- Neu thanh cong, se chuyen huong den trang admin

### 2. Tren Postman / REST Client

**Dang Ky:**
```bash
curl -X POST https://localhost:7047/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","matKhau":"password123"}'
```

**Dang Nhap:**
```bash
curl -X POST https://localhost:7047/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"email":"test@example.com","matKhau":"password123"}'
```

### 3. Tren VS Code REST Client
Dung file `test-auth.http` va nhan "Send Request"

### 4. Tren Swagger UI
```
https://localhost:7047/swagger/index.html
```
- Tim **Auth** section
- Click Try it out
- Nhap thong tin, nhan Execute

---

## Toi Uu Hoa & Cai Tien

| Tinh Nang | Trang Thai | Ghi Chu |
|-----------|-----------|--------|
| Dang Nhap Cvan Ban | ? Hoan thanh | Dang hoat dong |
| Dang Ky | ? Hoan thanh | Dang hoat dong |
| Ma Hoa Mat Khau | ? SHA256 | Ap dung |
| Xac Thuc Email Duy Nhat | ? Co | Kiem tra truoc dang ky |
| Luu User Token | ? Can them | Dung JWT tren next release |
| 2FA Authentication | ? Can them | Nang cao bao mat |
| Refresh Token | ? Can them | Tien loi su dung |
| Email Verification | ? Can them | Xac nhan email |
| Forgot Password | ? Can them | Lay lai mat khau |

---

## Loi Thuong Gap va Giai Phap

### Loi: 404 Not Found
**Nguyen nhan:** Controller khong duoc dang ky trong Program.cs  
**Giai phap:** Kiem tra `builder.Services.AddControllers()` va `app.MapControllers()`

### Loi: 400 Bad Request
**Nguyen nhan:** Thong tin dung hoac sai dinh dang  
**Giai phap:** Kiem tra JSON format va gia tri email/password

### Loi: 401 Unauthorized
**Nguyen nhan:** Email hoac mat khau sai  
**Giai phap:** Kiem tra lai email va mat khau

### Loi: 500 Internal Server Error
**Nguyen nhan:** Database khong ket noi  
**Giai phap:** Kiem tra connection string trong appsettings.json

---

## Bao Mat Luu Y

1. **Mat khau**: Luon ma hoa bang SHA256, khong bao gio luu mat khau plain text
2. **HTTPS**: Chi su dung tren HTTPS, khong HTTP
3. **CORS**: Hien tai cho phep toan bo origin, nen gioi han trong production
4. **Token**: Can them JWT token thay vi chi dung session
5. **Rate Limiting**: Can them de ngan brute force attack

---

## Cac Tep Lien Quan

- `LoginRequest.cs` - Model yeu cau dang nhap
- `LoginResponse.cs` - Model phan hoi dang nhap
- `NguoiDung.cs` - Model co so du lieu
- `AppDbContext.cs` - Database context
- `AuthController.cs` - Controller xu ly logic
- `login.html` - Giao dien web
- `test-auth.http` - Test cases

---

## Tham Khao

- [ASP.NET Core Authentication](https://learn.microsoft.com/en-us/aspnet/core/security/authentication)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [Swagger/OpenAPI](https://swagger.io/)

**Ngay Tao:** 2025-03-30  
**Phien Ban:** 1.0  
**Trang Thai:** Production Ready ?
