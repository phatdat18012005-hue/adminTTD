# ?? HE THONG QUAN TRI - HUONG DAN CHAY

## ? BUILD THANH CONG!

Ung dung da san sang chay. Day la huong dan chi tiet de chay tren Visual Studio Code.

---

## ?? YÊU CAU TIEN QUYET

- ? **.NET 8 SDK** - Tai tu https://dotnet.microsoft.com/download
- ? **SQL Server** - Chay tren PHATDAT (theo appsettings.json)
- ? **Visual Studio Code** - Tai tu https://code.visualstudio.com
- ? **Extensions (Tuy chon):**
  - C# DevKit
  - REST Client

---

## ?? CACH CHAY - NHAN NHAT

### Cach 1: Double-Click File (Toi Gian)
```
1. Double-click: run-app.bat
   (Hoac: run-app.ps1 tren PowerShell)

2. Doi 5-10 giay...

3. Tro duyet tu dong mo, hoac copy link tu terminal
```

### Cach 2: VS Code Terminal
```powershell
# 1. Open VS Code trong project folder
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?
code .

# 2. Mo Terminal (Ctrl+`)
# 3. Chap: dotnet run
# 4. Chap tren link trong output
```

### Cach 3: Command Line
```bash
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?
dotnet run
```

---

## ?? LINKS SAU KHI CHAY

Sau khi chay, tro duyet se hien cac duong dan:

| Port | URL | Mo Ta |
|------|-----|-------|
| 5046 | `http://localhost:5046` | HTTP |
| 7047 | `https://localhost:7047` | HTTPS |

### Cac Trang:
```
http://localhost:5046/                  # Trang chu
http://localhost:5046/login.html        # Dang nhap
http://localhost:5046/adminindex.html   # Trang admin
http://localhost:5046/swagger           # API doc
```

---

## ?? ADMIN DASHBOARD

### Dang Nhap:
1. Truy cap: `http://localhost:5046/login.html`
2. Dang ky tai khoan hoac dung tai khoan co san
3. Dang nhap => Vao trang Admin

### Tinh Nang:
- ?? **Dashboard** - Thong ke cong (Bai viet, Danh muc, Binh luan, Lien he)
- ?? **Quan ly Bai Viet** - CRUD (Tao, Doc, Cap nhat, Xoa)
- ?? **Danh Muc** - (Phien ban sau)
- ?? **Binh Luan** - (Phien ban sau)
- ?? **Lien He** - (Phien ban sau)
- ?? **Dang Xuat** - Thoat tai khoan

---

## ?? CACH CHAY TRONG VS CODE

### Buoc 1: Mo Folder
```
File > Open Folder
Chon: D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?
```

### Buoc 2: Mo Terminal
```
Terminal > New Terminal
Hoac: Ctrl+`
```

### Buoc 3: Chap Lenh
```powershell
dotnet run
```

### Buoc 4: Doi Output
```
Now listening on: http://localhost:5046
Now listening on: https://localhost:7047
```

### Buoc 5: Truy Cap
```
Click link trong output
Hoac: Copy-paste vao tro duyet
```

---

## ?? TEST API

### Dung REST Client Extension:

1. **Tao file:** `test-api.http`

2. **Them noi dung:**
```http
### Dang Nhap
POST http://localhost:5046/api/auth/login
Content-Type: application/json

{
  "email": "test@example.com",
  "matKhau": "password123"
}

### Lay Bai Viet
GET http://localhost:5046/api/baiviet

### Them Bai Viet
POST http://localhost:5046/api/baiviet
Content-Type: application/json

{
  "tieuDe": "Bai viet moi",
  "noiDung": "Noi dung demo",
  "trangThai": "Nha"
}
```

3. **Click "Send Request"** tren cac yeu cau

---

## ?? TROUBLESHOOT

### Loi 1: "dotnet command not found"
```bash
# Kiem tra da cai khong
dotnet --version

# Neu khong: Tai https://dotnet.microsoft.com/download
```

### Loi 2: "Port da duoc su dung"
```bash
# Tim process
netstat -ano | findstr :5046

# Ket thuc
taskkill /PID <PID> /F

# Hoac dung port khac
dotnet run --urls "http://localhost:3000"
```

### Loi 3: "HTTPS Certificate Error"
```
1. Click "Advanced" hoac "More options"
2. Click "Proceed anyway" hoac "Continue anyway"
3. Tiep tuc vao trang
```

### Loi 4: "Database khong ket noi"
```
1. Chac chan SQL Server dang chay
2. Kiem tra appsettings.json:
   - Server: PHATDAT (dung)
   - Database: TTD (co ton tai)
   - Trusted_Connection: True
```

### Loi 5: "Trang blank hoac loi 404"
```
1. Kiem tra port: 5046 hay 7047?
2. Chac chan dung dung URL: http://localhost:5046/
3. Chuoi URL quat trong console output
4. F5 reload trang
5. Ctrl+Shift+I (DevTools) > Console > Kiem tra loi
```

---

## ?? CAU TRUC PROJECT

```
adminTT?/
??? Controllers/
?   ??? AuthController.cs       # Dang nhap/Dang ky
?   ??? BaiVietController.cs    # Quan ly bai viet
??? Models/
?   ??? LoginRequest.cs
?   ??? LoginResponse.cs
?   ??? NguoiDung.cs
??? Migrations/
?   ??? 20260326085546_InitDB.cs
?   ??? 20260330005751_InitFullDatabase.cs
??? wwwroot/                    # Trang tinh (HTML/CSS/JS)
?   ??? index.html              # Trang chu
?   ??? login.html              # Dang nhap
?   ??? adminindex.html         # Trang admin (QUAN TRONG!)
?   ??? baiviet.html            # Quan ly bai viet
??? AppDbContext.cs             # Database
??? Program.cs                  # Cau hinh chinh
??? appsettings.json            # Cai dat ung dung
??? run-app.bat                 # Script chay (Windows)
??? run-app.ps1                 # Script chay (PowerShell)
??? README.md                   # File nay
```

---

## ?? API ENDPOINTS

### Authentication
```
POST   /api/auth/login       # Dang nhap
POST   /api/auth/register    # Dang ky
```

### Bai Viet
```
GET    /api/baiviet          # Lay tat ca
GET    /api/baiviet/{id}     # Lay theo ID
POST   /api/baiviet          # Tao moi
PUT    /api/baiviet/{id}     # Cap nhat
DELETE /api/baiviet/{id}     # Xoa
```

---

## ?? GIAO DIEN

### Login Page (`/login.html`)
- ? Form dang nhap
- ? Form dang ky
- ? Validate input
- ? Loading indicator
- ? Thong bao loi/thanh cong

### Admin Dashboard (`/adminindex.html`)
- ? Sidebar menu
- ? Top navigation
- ? Dashboard stats
- ? Bai viet table (CRUD)
- ? Responsive design

---

## ?? QUICK START

### OPTION 1: Nhanh nhat (1 click)
```
Double-click: run-app.bat
```

### OPTION 2: Tro duyet (2 dung)
```bash
# Terminal 1:
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?
dotnet run

# Browser:
# Truy cap: http://localhost:5046
```

### OPTION 3: VS Code (3 dung)
```
1. Ctrl+Shift+P > "Open in Default Browser"
2. VS Code mo tro duyet
3. Chap Ctrl+` de mo terminal
4. Chap: dotnet run
```

---

## ?? SUPPORT

Neu gap van de:
1. **Xem console output** - Thong bao loi co chi tiet
2. **F12 DevTools** - Kiem tra network va console
3. **appsettings.json** - Kiem tra database connection
4. **Firewall** - Chac chan cho phep ports 5046 va 7047

---

## ? TINH NANG SAP TOI

- [ ] Phan quyen (Admin, User)
- [ ] Upload anh/file
- [ ] Full-text search
- [ ] Pagination
- [ ] Notification system
- [ ] Email sending
- [ ] Analytics dashboard

---

## ?? GHI CHU

- **Port**: Thong thuong la 5046 (HTTP) hoac 7047 (HTTPS)
- **Database**: PHATDAT, Database TTD, Trusted Connection
- **HTTPS**: Normal, click "Proceed anyway"
- **Auto-reload**: Dung `dotnet watch run` thay vi `dotnet run`

---

**Chuc ban thanh cong! ??**

Tham khao them:
- `SETUP_VSCODE.md` - Chi tiet setup VS Code
- `FIXLOG.md` - Giai phap cac van de thuong gap
- `AUTH_GUIDE.md` - Chi tiet API xac thuc
- `COMPLETION_STATUS.md` - Trang thai hoan thanh

---

**Last Updated:** 2025-03-30  
**Status:** ? PRODUCTION READY
