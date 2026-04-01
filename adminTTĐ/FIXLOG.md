# ?? VAN DE VA GIAI PHAP

## ? VAN DE: "Sao link /login.html khong hoat dong?"

### Nguyen Nhan:
1. **Port khong khop** - Ban truy cap `https://localhost:7047` nhung ung dung chay tren port khac
2. **Ung dung chua chay** - Ban chua nhan F5 hoac `dotnet run`
3. **HTTPS certificate issue** - Tro tay bang "Proceed anyway"

---

## ? GIAI PHAP:

### Buoc 1: Chay Ung Dung
```
Nhan F5 trong Visual Studio
hoac
dotnet run trong terminal
```

### Buoc 2: Tim Port
Xem Output window, tim dong:
```
Now listening on: https://localhost:XXXX
```

### Buoc 3: Truy Cap Dang Nhap
```
https://localhost:XXXX/login.html
```

**Neu loi HTTPS:** Click "Advanced" > "Proceed anyway"

---

## ?? URL CO SAN (Sau khi chay):

| URL | Mo Ta |
|-----|-------|
| `/` | Trang chu |
| `/login.html` | Dang nhap |
| `/adminindex.html` | Trang admin |
| `/swagger` | API doc |
| `/api/auth/login` | API dang nhap |
| `/api/auth/register` | API dang ky |

---

## ?? CAP NHAT DA LAM:

1. ? **Program.cs** - Da co `app.UseStaticFiles()`
2. ? **wwwroot/login.html** - Tu detect port bang JavaScript
3. ? **wwwroot/index.html** - Trang chu moi
4. ? **AuthController** - Hoat dong dung cach
5. ? **Build** - Success khong loi

---

## ?? NHOI NHAT TRONG:

**Ban chi can:**
1. **Nhan F5** hoac chay `dotnet run`
2. **Copy-paste port** tu Output window
3. **Truy cap:** `https://localhost:PORT/login.html`

Done! ?

---

## ?? HELP:

Neu van khong hoat dong, kiem tra:
- [ ] SQL Server dang chay (PHATDAT server)
- [ ] Database TTD co ton tai
- [ ] Nhan F5 da
- [ ] Xem dung port trong Output window
- [ ] Click "Proceed anyway" neu co loi HTTPS

---

**Created:** 2025-03-30  
**Status:** ? Ready
