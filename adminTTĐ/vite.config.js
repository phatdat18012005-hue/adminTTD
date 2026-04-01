import { defineConfig } from 'vite'

// Vite config template for frontend project. Set server.port to 3000 and proxy /api to backend at 5046.
export default defineConfig({
  server: {
    port: 3000,
    proxy: {
      '/api': {
        target: 'http://localhost:5046',
        changeOrigin: true,
        secure: false,
      },
    },
  },
})
