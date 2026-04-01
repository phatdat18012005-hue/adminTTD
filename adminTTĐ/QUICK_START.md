# ?? TONG HOP - CACH CHAY VA KET NOI

## ? TINH TRANG HIEN TAI

- ? **Build:** Thanh cong - Khong co loi compile
- ? **API:** Dang nhap/Dang ky - Hoat dong
- ? **Admin Panel:** Da xong - Quan ly bai viet
- ? **Database:** Ket noi thanh cong
- ? **Authentication:** SHA256 ma hoa

---

## ?? BAT DAU CHAY (CHI 2 BUOC)

### BUOC 1: Chay Ung Dung
```bash
# Cach A: Double-click (Toi Gian)
run-app.bat

# Cach B: Terminal (VS Code)
Ctrl+` (mo terminal)
dotnet run

# Cach C: Command Line
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?
dotnet run
```

### BUOC 2: Truy Cap Link
```
http://localhost:5046
hoac
https://localhost:7047
```

**XONG! Trang chu hien ra!** ?

---

## ?? CAN LAM GI TU DAY

### 1. **Dang Nhap Admin**
   - Truy cap: `http://localhost:5046/login.html`
   - Dang ky tai khoan hoac dung tai khoan co san
   - Dang nhap => Vao `adminindex.html`

### 2. **Xem Trang Admin**
   - **Dashboard** - Thong ke
   - **Quan ly Bai Viet** - CRUD
   - **Danh Muc** - (Phien ban sau)
   - **Lien He** - (Phien ban sau)

### 3. **Test API**
   - **Swagger:** `https://localhost:7047/swagger`
   - **REST Client:** Dung file `.http` trong VS Code

---

## ?? CAN BIET

### Port La Gi?
- **5046** = HTTP (Khong an toan)
- **7047** = HTTPS (An toan, tro duyet se canh bao)

### Neu Thay Canh Bao HTTPS
```
Click "Advanced" hoac "More options"
Click "Proceed anyway" hoac "Continue anyway"
Tiep tuc
```

### Neu Chuong Trinh Khong Chay
```
1. Kiem tra SQL Server (Phatdat) dang chay
2. Kiem tra .NET SDK: dotnet --version
3. Xem console de tim loi
4. Kiem tra port chua duoc dung
```

---

## ?? GIAO DIEN CAN DAM

### Login (`/login.html`)
```
- Dang nhap
- Dang ky
- Responsive design
- Validation tren client
```

### Admin (`/adminindex.html`)
```
- Sidebar menu
- Top navigation (user info)
- Dashboard stats (so luong)
- Bai viet table (Them, sua, xoa)
- Icons va animation
- Auto-detect port
```

---

## ?? FILE CHINH

| File | Tac Dung |
|------|----------|
| `run-app.bat` | Script chay (Double-click) |
| `run-app.ps1` | Script chay (PowerShell) |
| `README.md` | Huong dan chi tiet |
| `SETUP_VSCODE.md` | Cau hinh VS Code |
| `AUTH_GUIDE.md` | API documentation |
| `FIXLOG.md` | Troubleshoot |

---

## ?? URL CAN BIET

```
/                    Trang chu
/login.html          Dang nhap (yeu cau truoc)
/adminindex.html     Trang admin (sau dang nhap)
/baiviet.html        Quan ly bai viet (cu)
/swagger             API documentation
/api/auth/login      API dang nhap
/api/auth/register   API dang ky
/api/baiviet         API bai viet
```

---

## ?? MHEO

### De Chay Nhanh
- Dung: `dotnet watch run` (auto-reload khi thay doi)
- Hoac: `dotnet run --configuration Release` (production)

### De Debug
- F5 trong Visual Studio (tuy chon khac)
- Hoac: `dotnet run` + Console.WriteLine()

### De Lam HTTPS Khong Co Canh Bao
- (Phuc tap, qua cau hoi nay)

---

## ? SAP TOI

```
[ ] Phan quyen (Admin vs User)
[ ] Upload anh
[ ] Search / Filter
[ ] Pagination
[ ] Email notification
[ ] Analytics
```

---

## ?? TONG KET

### Sau Khi Chay:
1. ? Trang chu hien ra
2. ? Click "Dang Nhap" => Login form
3. ? Dang nhap => Admin dashboard
4. ? Xem/Them/Sua/Xoa bai viet

### API Hoat Dong:
1. ? POST /api/auth/login
2. ? POST /api/auth/register
3. ? GET /api/baiviet
4. ? POST /api/baiviet
5. ? DELETE /api/baiviet/{id}

### Security:
1. ? Password: SHA256 ma hoa
2. ? Session: localStorage
3. ? CORS: Enabled
4. ? HTTPS: Supported

---

## ?? VAN DE?

**Neu gap loi:**
1. Xem console output - Co thong bao chi tiet
2. F12 DevTools - Kiem tra network
3. Kiem tra appsettings.json - Database connection
4. Chac chan SQL Server chay (PHATDAT)

**Neu khong biet port:**
```
Xem dong nay trong console khi chay:
  "Now listening on: http://localhost:XXXX"
```

---

## ?? CUOI CUNG

```bash
# 1. Chap:
dotnet run

# 2. Doi:
Now listening on: http://localhost:5046

# 3. Truy cap:
http://localhost:5046

# 4. Dang nhap va su dung!
```

**XONG! ?**

---

**Tham khao them:** README.md (file chi tiet)
