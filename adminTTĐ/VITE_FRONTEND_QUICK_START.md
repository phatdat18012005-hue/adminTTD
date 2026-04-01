# KET NOI VITE FRONTEND VOI .NET API (PORT 3000)

## CHU Y: Su dung port 3000 cho frontend (thay vi 5173/5174)

### CACH CAI DAT Nhanh
1. Trong project frontend (Vite), them file `vite.config.js` (see root of adminTT? for template) ho?c copy-n-paste:
```javascript
export default defineConfig({
  server: {
    port: 3000,
    proxy: {
      '/api': {
        target: 'http://localhost:5046',
        changeOrigin: true,
        secure: false
      }
    }
  }
})
```

2. Tao file `.env.development` trong frontend root:
```
VITE_API_URL=http://localhost:5046
PORT=3000
```

### Chay frontend tren port 3000
- Linux/macOS: `PORT=3000 npm run dev`
- Windows CMD: `set PORT=3000 && npm run dev`
- PowerShell: `$env:PORT=3000; npm run dev`

### Hoac dung `npm` script
- package.json:
```json
"scripts": {
  "dev": "vite --port 3000",
  "start": "vite"
}
```

### Proxy /api sang backend
- Khi proxy cai dat, frontend co the goi `/api/...` va Vite se forward toi `http://localhost:5046/api/...`

---

## KIEM TRA
1. Chay backend: `dotnet run` -> `Now listening on: http://localhost:5046`.
2. Chay frontend: `npm run dev` (hoac set PORT=3000 && npm run dev) -> `http://localhost:3000`.
3. Truy cap: `http://localhost:3000/admin/login`.
4. Test login: console fetch to `http://localhost:5046/api/auth/login` (proxy allows `/api` too).

---

## GHI CHU
- Backend Program.cs da cho phep origin `http://localhost:3000`.
- frontend-api-config.js co san trong repo - copy sang frontend project va su dung `import.meta.env.VITE_API_URL`.
