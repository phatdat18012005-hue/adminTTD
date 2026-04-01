# HUONG DAN CHAY UNGDUNG

## ? Build Da Thanh Cong!

Ung dung da san sang chay. Tuy nhien, ban can biet port nao ma ung dung chay tren.

---

## ?? Cach Chay Ung Dung

### Option 1: Chay Tren Visual Studio
1. **Nhan F5** hoac **Click "Start" button**
2. Ung dung se tu dong mo tren browser voi port mac dinh
3. Thong thuong la: `https://localhost:7047` hoac `https://localhost:7000`

### Option 2: Chay Tren Terminal
```bash
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?
dotnet run
```

### Option 3: Build va Run
```bash
dotnet build
dotnet run
```

---

## ?? Tim Dung Duong Link

Sau khi chay, ban se thay URL trong browser bar, vi du:
- `https://localhost:7047`
- `https://localhost:7000`
- `https://localhost:5001`

### Truy Cap Cac Duong Dan:

| URL | Mo Ta |
|-----|-------|
| `https://localhost:PORT/` | Trang chu chinh |
| `https://localhost:PORT/login.html` | Trang dang nhap |
| `https://localhost:PORT/swagger` | API Documentation |
| `https://localhost:PORT/api/auth/login` | API dang nhap |
| `https://localhost:PORT/api/auth/register` | API dang ky |

**Thay `PORT` bang port ma ung dung chay tren (7047, 7000, 5001, v.v.)**

---

## ?? Kiem Tra Port Ung Dung

### C1: Xem trong Visual Studio Output
Sau khi F5, xem **Output window** (View > Output), se thay dong nhu sau:
```
Now listening on: https://localhost:7047
Now listening on: http://localhost:5046
Application started. Press Ctrl+C to quit.
```

### C2: Xem trong Console
Neu chay bang `dotnet run`, se thay port trong console output.

---

## ? Truy Cap Dang Nhap

Sau khi tim duoc port, truy cap:

```
https://localhost:PORT/login.html
```

**Neu thay loi HTTPS certificate:**
- Click "Advanced" hoac "Proceed anyway"
- Chon "Accept risk"
- Tiep tuc vao trang

---

## ?? Cam On Su Dung!

Ung dung da san sang! Ban co the:
1. **Dang ky tai khoan** - Click "Dang ky ngay"
2. **Dang nhap** - Dung email va password vua tao
3. **Su dung API** - Truy cap /swagger de test

---

## ?? Neu Khong Hoat Dong

### Kiem tra:
1. **Database**: Chac chan SQL Server dang chay
   - Connection String trong `appsettings.json`
   - Server: `PHATDAT`
   - Database: `TTD`

2. **Port**: Kiem tra port trong output window

3. **Firewall**: Chac chan firewall cho phep port

4. **HTTPS**: Neu khong ho tro HTTPS, su dung HTTP
   - `http://localhost:PORT/login.html`

### Chi Tiet Ket Noi Database:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=PHATDAT;Database=TTD;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

Neu van loi, kiem tra:
- SQL Server dang chay
- Username/password (neu dung SQL Auth)
- Database TTD da duoc tao

---

## ?? Cau Truc Trang:

```
wwwroot/
??? index.html       ? Trang chu, link toi login
??? login.html       ? Trang dang nhap/dang ky
??? adminindex.html  ? Trang admin (sau dang nhap)
??? baiviet.html     ? Trang bai viet
```

---

**Hay nhan F5 hoac `dotnet run` va truy cap link!** ??
