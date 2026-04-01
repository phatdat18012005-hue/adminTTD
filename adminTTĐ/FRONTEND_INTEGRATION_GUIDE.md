# KET NOI FRONTEND (VUE/REACT) VOI API .NET

## ?? TINH HUONG: 
- **Frontend:** http://localhost:5173 (Vue/React/Vite)
- **Backend API:** http://localhost:5046 (ASP.NET Core)

---

## ? BUOC 1: CHAY BACKEND API

### Terminal 1: Chay API
```bash
cd D:\Tran Nguyen Phat Dat-0023411535\adminTT?\adminTT?
dotnet run
```

Output se hien:
```
Now listening on: http://localhost:5046
Now listening on: https://localhost:7047
```

---

## ? BUOC 2: CHAY FRONTEND

### Terminal 2: Chay Frontend
```bash
cd D:\duong-dan-frontend-cua-ban
npm run dev
```

Output se hien:
```
VITE v5.0.0  ready in XXX ms

? Local:   http://localhost:5173/
```

---

## ? BUOC 3: SU DUNG API TRONG FRONTEND

### A. VUE (Composition API)

**File: src/api/client.js**
```javascript
// Copy noi dung tu file: frontend-api-config.js

import { ref } from 'vue'
import { API_ENDPOINTS, login, register, getBaiViet } from '@/api/client'

export default {
  setup() {
    const email = ref('')
    const password = ref('')
    const loading = ref(false)

    const handleLogin = async () => {
      loading.value = true
      const result = await login(email.value, password.value)

      if (result.success) {
        localStorage.setItem('user', JSON.stringify(result.data.user))
        // Chuyen den trang chinh
        router.push('/admin')
      } else {
        alert('Login that bai: ' + result.error)
      }

      loading.value = false
    }

    return { email, password, loading, handleLogin }
  }
}
```

**File: src/views/Login.vue**
```vue
<template>
  <div class="login-container">
    <h1>Dang Nhap</h1>

    <input 
      v-model="email" 
      type="email" 
      placeholder="Email"
    />

    <input 
      v-model="password" 
      type="password" 
      placeholder="Password"
    />

    <button @click="handleLogin" :disabled="loading">
      {{ loading ? 'Dang xu ly...' : 'Dang Nhap' }}
    </button>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { login } from '@/api/client'
import { useRouter } from 'vue-router'

const router = useRouter()
const email = ref('')
const password = ref('')
const loading = ref(false)

const handleLogin = async () => {
  loading.value = true
  const result = await login(email.value, password.value)

  if (result.success) {
    localStorage.setItem('user', JSON.stringify(result.data.user))
    router.push('/admin')
  } else {
    alert('Login that bai: ' + result.error)
  }

  loading.value = false
}
</script>
```

### B. REACT

**File: src/api/client.js**
```javascript
// Copy noi dung tu file: frontend-api-config.js

export const login = async (email, password) => {
  try {
    const response = await fetch('http://localhost:5046/api/auth/login', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ email, matKhau: password })
    })

    if (!response.ok) throw new Error('Login failed')
    return await response.json()
  } catch (error) {
    return { success: false, message: error.message }
  }
}
```

**File: src/pages/Login.jsx**
```jsx
import { useState } from 'react'
import { login } from '../api/client'
import { useNavigate } from 'react-router-dom'

export default function Login() {
  const navigate = useNavigate()
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)

  const handleLogin = async (e) => {
    e.preventDefault()
    setLoading(true)

    const result = await login(email, password)

    if (result.success) {
      localStorage.setItem('user', JSON.stringify(result.user))
      navigate('/admin')
    } else {
      alert('Login that bai: ' + result.message)
    }

    setLoading(false)
  }

  return (
    <div className="login-container">
      <h1>Dang Nhap</h1>

      <form onSubmit={handleLogin}>
        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          required
        />

        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />

        <button type="submit" disabled={loading}>
          {loading ? 'Dang xu ly...' : 'Dang Nhap'}
        </button>
      </form>
    </div>
  )
}
```

### C. SVELTE

**File: src/api/client.js**
```javascript
// Copy noi dung tu file: frontend-api-config.js
```

**File: src/routes/login/+page.svelte**
```svelte
<script>
  import { goto } from '$app/navigation'
  import { login } from '../../api/client'

  let email = ''
  let password = ''
  let loading = false

  async function handleLogin() {
    loading = true
    const result = await login(email, password)

    if (result.success) {
      localStorage.setItem('user', JSON.stringify(result.data.user))
      await goto('/admin')
    } else {
      alert('Login that bai: ' + result.error)
    }

    loading = false
  }
</script>

<div class="login-container">
  <h1>Dang Nhap</h1>

  <input
    bind:value={email}
    type="email"
    placeholder="Email"
  />

  <input
    bind:value={password}
    type="password"
    placeholder="Password"
  />

  <button on:click={handleLogin} disabled={loading}>
    {loading ? 'Dang xu ly...' : 'Dang Nhap'}
  </button>
</div>
```

---

## ?? CORS Configuration (Backend)

**Da xu ly trong Program.cs:**

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", builder =>
    {
        builder.WithOrigins(
            "http://localhost:5173",    // Vite dev
            "http://localhost:5046",    // Backend dev
            "http://localhost:3000"     // CRA dev
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

app.UseCors("AllowFrontend");
```

? Da set up - Khong can thay doi!

---

## ?? KIEN THUC CAN BIET

### Trong Frontend, Khi Goi API:

```javascript
// DUNG (tu dong detect port)
const API_URL = 'http://localhost:5046'

// KHONG (hard-code localhost:7047 la HTTPS)
const API_URL = 'https://localhost:7047' // Se khong hoat dong
```

### Headers Can Thiet:

```javascript
const headers = {
  'Content-Type': 'application/json'
}

// Neu co token (sau nay):
const headers = {
  'Content-Type': 'application/json',
  'Authorization': `Bearer ${token}`
}
```

---

## ?? FLOW DANG NHAP

```
Frontend (5173)
    ?
User click "Dang Nhap"
    ?
POST /api/auth/login (to 5046)
    ?
Backend (5046)
    ?
Check email + password
    ?
Return user info + token
    ?
Frontend (5173)
    ?
Save localStorage
    ?
Redirect /admin
    ?
Hien trang admin
```

---

## ?? TEST API TU FRONTEND CONSOLE

**Chrome DevTools Console:**

```javascript
// Test dang nhap
const response = await fetch('http://localhost:5046/api/auth/login', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify({ 
    email: 'test@example.com', 
    matKhau: 'password123' 
  })
})

const data = await response.json()
console.log(data)
```

---

## ? ADVANCED: Environment Variables

**File: .env.local (Frontend)**

```
VITE_API_URL=http://localhost:5046
VITE_API_TIMEOUT=5000
```

**File: vite.config.js**

```javascript
export default {
  server: {
    proxy: {
      '/api': {
        target: 'http://localhost:5046',
        changeOrigin: true,
        secure: false
      }
    }
  }
}
```

---

## ?? THAM KHAO

### File Co San:
- `frontend-api-config.js` - API config cho frontend
- `Program.cs` - Backend CORS setup

### Swagger API Docs:
```
https://localhost:7047/swagger
```

### Networks Tab (DevTools):
1. Click chuot phai > Inspect
2. Network tab
3. Xem request/response toi API

---

## ?? SUMMARY

```
BACKEND:  dotnet run         ? http://localhost:5046
FRONTEND: npm run dev        ? http://localhost:5173

Frontend goi:
  POST http://localhost:5046/api/auth/login

Backend tra ve:
  { success: true, user: {...}, message: "..." }

Frontend xu ly:
  localStorage.setItem('user', ...)
  router.push('/admin')
```

---

**READY TO GO!** ??

Dat file `frontend-api-config.js` trong project frontend cua ban va su dung!
