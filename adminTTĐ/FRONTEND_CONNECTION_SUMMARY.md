# ?? KET NOI FRONTEND (5173) VOI BACKEND (.NET 5046)

## ? TINH TRANG

- ? **Backend:** http://localhost:5046 (ASP.NET Core)
- ? **Frontend:** http://localhost:5173 (Vue/React/Vite)
- ? **CORS:** Da cau hinh cho phep 5173
- ? **API:** San sang ket noi

---

## ?? BAT DAU NHANH (2 TERMINAL)

### Terminal 1: Chay Backend
```bash
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?
dotnet run
```

### Terminal 2: Chay Frontend
```bash
cd [duong-dan-vite-project]
npm run dev
```

### Browser: Truy cap
```
http://localhost:5173/admin/login
```

---

## ?? CODE MAU (Copy-Paste)

### JavaScript (Pho bien nhat)
```javascript
// Trong frontend, tao file: src/api.js

const API_URL = 'http://localhost:5046/api'

export async function login(email, password) {
  const response = await fetch(`${API_URL}/auth/login`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ email, matKhau: password })
  })
  return response.json()
}

export async function register(email, password) {
  const response = await fetch(`${API_URL}/auth/register`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ email, matKhau: password })
  })
  return response.json()
}

export async function getBaiViet() {
  const response = await fetch(`${API_URL}/baiviet`)
  return response.json()
}
```

### Vue 3
```vue
<script setup>
import { ref } from 'vue'
import { login } from '@/api'

const email = ref('')
const password = ref('')
const loading = ref(false)

async function handleLogin() {
  loading.value = true
  const result = await login(email.value, password.value)

  if (result.success) {
    localStorage.setItem('user', JSON.stringify(result.user))
    // Chuyen trang
  }
  loading.value = false
}
</script>
```

### React
```jsx
import { useState } from 'react'
import { login } from '@/api'

function LoginPage() {
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)

  const handleLogin = async () => {
    setLoading(true)
    const result = await login(email, password)

    if (result.success) {
      localStorage.setItem('user', JSON.stringify(result.user))
      // Chuyen trang
    }
    setLoading(false)
  }

  return (
    <form onSubmit={e => { e.preventDefault(); handleLogin() }}>
      <input value={email} onChange={e => setEmail(e.target.value)} />
      <input type="password" value={password} onChange={e => setPassword(e.target.value)} />
      <button>{loading ? 'Loading...' : 'Login'}</button>
    </form>
  )
}
```

---

## ?? API ENDPOINTS

```
POST   http://localhost:5046/api/auth/login
POST   http://localhost:5046/api/auth/register
GET    http://localhost:5046/api/baiviet
POST   http://localhost:5046/api/baiviet
PUT    http://localhost:5046/api/baiviet/{id}
DELETE http://localhost:5046/api/baiviet/{id}
```

---

## ?? LUU Y QUAN TRONG

### 1. **API URL**
```
? DUNG:    http://localhost:5046
? KHONG:  https://localhost:7047 (HTTPS se khong hoat dong)
```

### 2. **Request Body**
```javascript
// Backend dung 'matKhau' KHONG phai 'password'
? { email: "...", matKhau: "..." }
? { email: "...", password: "..." }
```

### 3. **Response Format**
```json
{
  "success": true,
  "message": "Dang nhap thanh cong",
  "user": {
    "id": 1,
    "email": "test@example.com",
    "ten": null,
    "vaiTro": "user"
  }
}
```

---

## ?? FILE CAN CO

Trong backend folder (`adminTT?`):
- ? `frontend-api-config.js` - Config mau
- ? `frontend-code-examples.js` - Code examples
- ? `FRONTEND_INTEGRATION_GUIDE.md` - Chi tiet
- ? `VITE_FRONTEND_QUICK_START.md` - Quick start
- ? `Program.cs` - CORS da set up

---

## ?? TEST NGAY

### Browser Console:
```javascript
fetch('http://localhost:5046/api/auth/login', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({ email: 'test@example.com', matKhau: 'password' })
}).then(r => r.json()).then(d => console.log(d))
```

### Swagger:
```
https://localhost:7047/swagger
```

---

## ?? TROUBLESHOOT

### Loi: CORS Policy blocked
```
Nguyen nhan: Frontend port khong trong whitelist
Giai phap: Check Program.cs - da add http://localhost:5173
```

### Loi: 404 Not Found
```
Nguyen nhan: URL sai hoac endpoint khong ton tai
Giai phap: Kiem tra exact endpoint path
```

### Loi: Network failed
```
Nguyen nhan: Backend khong chay hoac wrong port
Giai phap: Kiem tra dotnet run output
```

### Loi: Invalid JSON
```
Nguyen nhan: Request body sai format
Giai phap: Dung { email, matKhau } DUNG, khong phai { email, password }
```

---

## ?? THAM KHAO CHI TIET

| File | Mo Ta |
|------|-------|
| VITE_FRONTEND_QUICK_START.md | Quick start (toi gian) |
| FRONTEND_INTEGRATION_GUIDE.md | Toan bo chi tiet |
| frontend-api-config.js | Config co san |
| frontend-code-examples.js | Code examples day du |

---

## ? SUMMARY

```
BACKEND (5046):
  ? API san sang
  ? CORS enabled cho 5173
  ? Authentication hoat dong
  ? Database ket noi

FRONTEND (5173):
  ? Copy file mau: frontend-api-config.js
  ? Tao api.js hoac api.ts
  ? Goi trong component
  ? Save token/user vao localStorage
  ? DONE!
```

---

## ?? NEXT STEPS

```
1. Copy frontend-api-config.js vao project
2. Tao API service class
3. Goi login() trong component
4. Save user vao localStorage
5. Redirect to /admin
6. Hien trang admin
7. SUCCESS! ?
```

---

**READY TO CONNECT!** ??

Dat file `frontend-api-config.js` vao project va bat dau!
