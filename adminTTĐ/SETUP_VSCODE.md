# HUONG DAN KET NOI VA CHAY TREN VISUAL STUDIO CODE

## ? BUOC 1: Mo Du An Trong VS Code

### Cach 1: Dung Terminal
```bash
# Cd den thu muc project
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?

# Mo VS Code
code .
```

### Cach 2: Mo Truc Tiep
- **File** > **Open Folder**
- Chon folder: `D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?`
- Click **Select Folder**

---

## ? BUOC 2: Cai Dat Extensions (Tuy Chon)

Trong VS Code, cai dat cac extensions nay:

| Extension | Ten | Tim | Tac Dung |
|-----------|-----|-----|----------|
| C# | C# | C# DevKit | Chi tro code C# |
| REST Client | REST Client | REST Client | Test API |

**Cach cai dat:**
1. Click icon Extensions (Ctrl+Shift+X)
2. Tim ten extension
3. Click Install

---

## ? BUOC 3: Chay Ung Dung

### Option A: Dung Terminal Trong VS Code

1. **Mo Terminal:**
   - Press `Ctrl+` hoac **Terminal** > **New Terminal**

2. **Chay ung dung:**
```bash
dotnet run
```

3. **Output se hien ra:**
```
Now listening on: https://localhost:7047
Now listening on: http://localhost:5046
Application started. Press Ctrl+C to quit.
```

### Option B: Dung .NET CLI

```bash
# Trong terminal
dotnet watch run
```

(`watch` se tu reload khi co thay doi code)

---

## ?? BUOC 4: Truy Cap Ung Dung

### Link Chinh:
```
http://localhost:5046       # HTTP
https://localhost:7047      # HTTPS
```

### Cac Trang:
| URL | Mo Ta |
|-----|-------|
| `/` | Trang chu |
| `/login.html` | Dang nhap |
| `/adminindex.html` | Trang admin |
| `/swagger` | API Documentation |

---

## ?? BUOC 5: Test API Trong VS Code

### Dung REST Client Extension:

1. **Tao file test:** `test.http`

2. **Them noi dung:**
```http
### Test Dang Ky
POST http://localhost:5046/api/auth/register
Content-Type: application/json

{
  "email": "test@example.com",
  "matKhau": "password123"
}

### Test Dang Nhap
POST http://localhost:5046/api/auth/login
Content-Type: application/json

{
  "email": "test@example.com",
  "matKhau": "password123"
}

### Lay Danh Sach Bai Viet
GET http://localhost:5046/api/baiviet
```

3. **Click "Send Request"** tren moi request

---

## ?? BUOC 6: Mo Trang Trong Tro Duyet

**C1: Command Palette**
- Press `Ctrl+Shift+P`
- Tim: "Open in Default Browser"
- Chon link

**C2: Tu Dong Mo**
```bash
# Trong Terminal, sau khi chay dotnet run
# Click vao link trong output
```

**C3: Copy-Paste Manual**
- Copy: `http://localhost:5046/adminindex.html`
- Paste vao tro duyet

---

## ?? TROUBLESHOOT

### Loi: "dotnet command not found"
**Giai Phap:**
```bash
# Kiem tra da cai .NET SDK chua
dotnet --version

# Neu chua cai, tai tu https://dotnet.microsoft.com/download
```

### Loi: "Port 5046/7047 dang duoc su dung"
**Giai Phap:**
```bash
# Kiem tra process dang chay port
netstat -ano | findstr :5046

# Ket thuc process
taskkill /PID <PID> /F

# Hoac chay tren port khac
dotnet run --urls "http://localhost:3000"
```

### Loi: "HTTPS Certificate"
**Giai Phap:**
1. Click "Advanced" trong tro duyet
2. Click "Proceed anyway"
3. Tiep tuc vao trang

### Loi: "Khong ket noi duoc database"
**Kiem tra:**
- [ ] SQL Server dang chay
- [ ] Connection string dung trong `appsettings.json`
- [ ] Database `TTD` da duoc tao

**Sua:**
```json
// appsettings.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=PHATDAT;Database=TTD;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

---

## ?? QTRN HUONG DAN NHANH

### Buoc 1-3 (Lan Dau):
```bash
# 1. Cd den project
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?

# 2. Mo VS Code
code .

# 3. Chay trong terminal
dotnet run
```

### Lan Sau:
```bash
# Trong VS Code Terminal
dotnet run

# Hoac voi auto-reload:
dotnet watch run

# Truy cap: http://localhost:5046
```

---

## ? TINH NANG TRONG ADMIN

### Trang Admin (`/adminindex.html`):
- ? Dashboard - Thong ke
- ? Quan ly Bai Viet - CRUD
- ? Danh Muc - (Phien ban sau)
- ? Binh Luan - (Phien ban sau)
- ? Lien He - (Phien ban sau)
- ? Dang Xuat

### API Endpoints:
```
POST   /api/auth/login       - Dang nhap
POST   /api/auth/register    - Dang ky
GET    /api/baiviet          - Lay danh sach
POST   /api/baiviet          - Tao moi
DELETE /api/baiviet/{id}     - Xoa
PUT    /api/baiviet/{id}     - Cap nhat
```

---

## ?? KET QUA KY VONG

Sau khi chay thanh cong:

1. **Terminal hien:**
   ```
   Now listening on: http://localhost:5046
   Now listening on: https://localhost:7047
   ```

2. **Browser hien:**
   - Trang chu voi link dang nhap
   - Dang nhap => Trang admin
   - Admin co dashboard va quan ly bai viet

3. **API hoat dong:**
   - Test tren Swagger: `https://localhost:7047/swagger`
   - Test tren REST Client trong VS Code

---

## ?? FINAL NOTES

- **Port**: Hay xem output de lay port chinh xac (5046 hoac 7047)
- **HTTPS**: Normal, click "Proceed anyway"
- **Database**: Can SQL Server chay
- **Firewall**: Chac chan cho phep port

---

**Chuc ban thanh cong! ??**

Neu co cau hoi hoac loi, kiem tra:
1. Output console
2. Browser F12 (Network tab)
3. File `appsettings.json`
