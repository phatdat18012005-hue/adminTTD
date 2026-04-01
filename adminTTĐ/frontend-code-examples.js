/**
 * Frontend Integration - JavaScript/TypeScript Examples
 * 
 * Su dung cho: Vue 3, React, Svelte, Vite projects
 * Ket noi toi: Backend ASP.NET Core (http://localhost:5046)
 */

// =====================================================
// 1. BASIC FETCH (Khong dung library)
// =====================================================

const API_URL = 'http://localhost:5046/api'

// Login
async function basicLogin(email, password) {
  try {
    const response = await fetch(`${API_URL}/auth/login`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        email: email,
        matKhau: password  // Chu y: backend dung 'matKhau' chu khong phai 'password'
      })
    })

    const data = await response.json()

    if (data.success) {
      console.log('Login thanh cong:', data.user)
      localStorage.setItem('currentUser', JSON.stringify(data.user))
      return { success: true, user: data.user }
    } else {
      console.error('Login that bai:', data.message)
      return { success: false, message: data.message }
    }
  } catch (error) {
    console.error('Network error:', error)
    return { success: false, message: error.message }
  }
}

// =====================================================
// 2. API SERVICE CLASS (Recommended)
// =====================================================

class ApiService {
  constructor(baseUrl = 'http://localhost:5046/api') {
    this.baseUrl = baseUrl
    this.headers = {
      'Content-Type': 'application/json'
    }
  }

  // Authentication
  async login(email, matKhau) {
    return this.post('/auth/login', { email, matKhau })
  }

  async register(email, matKhau) {
    return this.post('/auth/register', { email, matKhau })
  }

  // Bai Viet
  async getBaiViet() {
    return this.get('/baiviet')
  }

  async getBaiVietById(id) {
    return this.get(`/baiviet/${id}`)
  }

  async createBaiViet(data) {
    return this.post('/baiviet', data)
  }

  async updateBaiViet(id, data) {
    return this.put(`/baiviet/${id}`, data)
  }

  async deleteBaiViet(id) {
    return this.delete(`/baiviet/${id}`)
  }

  // Internal methods
  async get(endpoint) {
    const response = await fetch(`${this.baseUrl}${endpoint}`, {
      method: 'GET',
      headers: this.headers
    })
    return this.handleResponse(response)
  }

  async post(endpoint, data) {
    const response = await fetch(`${this.baseUrl}${endpoint}`, {
      method: 'POST',
      headers: this.headers,
      body: JSON.stringify(data)
    })
    return this.handleResponse(response)
  }

  async put(endpoint, data) {
    const response = await fetch(`${this.baseUrl}${endpoint}`, {
      method: 'PUT',
      headers: this.headers,
      body: JSON.stringify(data)
    })
    return this.handleResponse(response)
  }

  async delete(endpoint) {
    const response = await fetch(`${this.baseUrl}${endpoint}`, {
      method: 'DELETE',
      headers: this.headers
    })
    return this.handleResponse(response)
  }

  async handleResponse(response) {
    if (!response.ok) {
      throw new Error(`HTTP Error: ${response.status}`)
    }
    return response.json()
  }
}

// Su dung:
const api = new ApiService()
const result = await api.login('test@example.com', 'password123')

// =====================================================
// 3. AXIOS EXAMPLE (Neu su dung axios)
// =====================================================

/*
npm install axios

import axios from 'axios'

const axiosInstance = axios.create({
  baseURL: 'http://localhost:5046/api',
  headers: {
    'Content-Type': 'application/json'
  }
})

// Login
async function loginWithAxios(email, password) {
  try {
    const response = await axiosInstance.post('/auth/login', {
      email,
      matKhau: password
    })
    return response.data
  } catch (error) {
    console.error('Error:', error.response?.data || error.message)
    throw error
  }
}
*/

// =====================================================
// 4. VUE 3 COMPOSABLE
// =====================================================

/*
// composables/useAuth.js
import { ref } from 'vue'
import { useRouter } from 'vue-router'

const api = new ApiService()

export function useAuth() {
  const router = useRouter()
  const user = ref(null)
  const loading = ref(false)
  const error = ref(null)

  const login = async (email, matKhau) => {
    loading.value = true
    error.value = null

    try {
      const result = await api.login(email, matKhau)

      if (result.success) {
        user.value = result.user
        localStorage.setItem('currentUser', JSON.stringify(result.user))
        router.push('/admin')
      } else {
        error.value = result.message
      }
    } catch (err) {
      error.value = err.message
    } finally {
      loading.value = false
    }
  }

  const logout = () => {
    user.value = null
    localStorage.removeItem('currentUser')
    router.push('/login')
  }

  // Check if user logged in
  const checkAuth = () => {
    const stored = localStorage.getItem('currentUser')
    if (stored) {
      user.value = JSON.parse(stored)
    }
  }

  return { user, loading, error, login, logout, checkAuth }
}

// Trong component:
// <script setup>
// import { useAuth } from '@/composables/useAuth'
// const { user, loading, login } = useAuth()
// </script>
*/

// =====================================================
// 5. REACT HOOK
// =====================================================

/*
// hooks/useAuth.js
import { useState } from 'react'
import { useNavigate } from 'react-router-dom'

const api = new ApiService()

export function useAuth() {
  const navigate = useNavigate()
  const [user, setUser] = useState(null)
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState(null)

  const login = async (email, matKhau) => {
    setLoading(true)
    setError(null)

    try {
      const result = await api.login(email, matKhau)

      if (result.success) {
        setUser(result.user)
        localStorage.setItem('currentUser', JSON.stringify(result.user))
        navigate('/admin')
      } else {
        setError(result.message)
      }
    } catch (err) {
      setError(err.message)
    } finally {
      setLoading(false)
    }
  }

  const logout = () => {
    setUser(null)
    localStorage.removeItem('currentUser')
    navigate('/login')
  }

  return { user, loading, error, login, logout }
}

// Trong component:
// function LoginPage() {
//   const { login, loading } = useAuth()
//   // ...
// }
*/

// =====================================================
// 6. INTERCEPTOR (Them token vao moi request)
// =====================================================

class ApiServiceWithAuth extends ApiService {
  async request(method, endpoint, data = null) {
    const token = localStorage.getItem('token')
    const headers = { ...this.headers }

    if (token) {
      headers['Authorization'] = `Bearer ${token}`
    }

    const config = {
      method,
      headers
    }

    if (data) {
      config.body = JSON.stringify(data)
    }

    const response = await fetch(`${this.baseUrl}${endpoint}`, config)
    return this.handleResponse(response)
  }

  async get(endpoint) {
    return this.request('GET', endpoint)
  }

  async post(endpoint, data) {
    return this.request('POST', endpoint, data)
  }

  async put(endpoint, data) {
    return this.request('PUT', endpoint, data)
  }

  async delete(endpoint) {
    return this.request('DELETE', endpoint)
  }
}

// =====================================================
// 7. LOADING & ERROR STATE MANAGEMENT
// =====================================================

class ApiState {
  constructor() {
    this.loading = false
    this.error = null
    this.data = null
  }

  setLoading(value) {
    this.loading = value
  }

  setError(error) {
    this.error = error
  }

  setData(data) {
    this.data = data
  }

  reset() {
    this.loading = false
    this.error = null
    this.data = null
  }
}

// =====================================================
// 8. ENVIRONMENT-BASED CONFIG
// =====================================================

const isDevelopment = process.env.NODE_ENV === 'development'

const API_CONFIG = {
  baseUrl: isDevelopment 
    ? 'http://localhost:5046/api'
    : 'https://api.production.com/api',
  timeout: 5000,
  retries: 3
}

const api = new ApiService(API_CONFIG.baseUrl)

// =====================================================
// 9. ERROR HANDLING BEST PRACTICES
// =====================================================

class ApiError extends Error {
  constructor(message, status, data) {
    super(message)
    this.name = 'ApiError'
    this.status = status
    this.data = data
  }
}

async function safeApiCall(apiFunction) {
  try {
    const result = await apiFunction()
    return { success: true, data: result }
  } catch (error) {
    console.error('API Error:', error)

    let message = 'Co loi xay ra'

    if (error instanceof ApiError) {
      message = error.message

      // Handle specific status codes
      if (error.status === 401) {
        // Unauthorized - redirect to login
        window.location.href = '/login'
      } else if (error.status === 403) {
        // Forbidden - show permission error
        message = 'Ban khong co quyen truy cap'
      }
    }

    return { success: false, error: message }
  }
}

// Su dung:
const result = await safeApiCall(() => api.login('email', 'password'))

// =====================================================
// EXPORT
// =====================================================

export { ApiService, ApiServiceWithAuth, useAuth }
