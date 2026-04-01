// frontend-api-config.js
// Use this file in your frontend project (Vite/CRA). It picks up VITE_API_URL when running under Vite.

// ============================================
// API Configuration cho Vite Frontend
// ============================================

// Detect backend URL (Local or Production)
const getBackendUrl = () => {
  // Vite exposes env vars through import.meta.env
  try {
    // eslint-disable-next-line no-undef
    if (typeof import !== 'undefined' && typeof import.meta !== 'undefined' && import.meta.env && import.meta.env.VITE_API_URL) {
      return import.meta.env.VITE_API_URL;
    }
  } catch (e) {
    // ignore in non-vite env
  }

  if (typeof process !== 'undefined' && process.env && process.env.VITE_API_URL) {
    return process.env.VITE_API_URL;
  }

  // Fallback to local backend URL
  return 'http://localhost:5046';
};

export const API_BASE_URL = getBackendUrl();

// ============================================
// API Endpoints
// ============================================

export const API_ENDPOINTS = {
  // Authentication
  auth: {
    login: `${API_BASE_URL}/api/auth/login`,
    register: `${API_BASE_URL}/api/auth/register`,
  },

  // Bai Viet
  baiViet: {
    list: `${API_BASE_URL}/api/baiviet`,
    detail: (id) => `${API_BASE_URL}/api/baiviet/${id}`,
    create: `${API_BASE_URL}/api/baiviet`,
    update: (id) => `${API_BASE_URL}/api/baiviet/${id}`,
    delete: (id) => `${API_BASE_URL}/api/baiviet/${id}`,
  },
};

// ============================================
// Fetch wrapper voi error handling
// ============================================

export const apiCall = async (method, url, data = null, headers = {}) => {
  const defaultHeaders = {
    'Content-Type': 'application/json',
    ...headers,
  };

  const config = {
    method,
    headers: defaultHeaders,
  };

  if (data) {
    config.body = JSON.stringify(data);
  }

  try {
    const response = await fetch(url, config);

    if (!response.ok) {
      const text = await response.text();
      let err;
      try { err = JSON.parse(text); } catch { err = { message: text }; }
      throw new Error(err.message || `HTTP Error: ${response.status}`);
    }

    const result = await response.json();
    return { success: true, data: result };
  } catch (error) {
    return { success: false, error: error.message };
  }
};

// ============================================
// Cac ham ti?n loi
// ============================================

// Dang nhap
export const login = async (email, matKhau) => {
  return apiCall('POST', API_ENDPOINTS.auth.login, { email, matKhau });
};

// Dang ky
export const register = async (email, matKhau) => {
  return apiCall('POST', API_ENDPOINTS.auth.register, { email, matKhau });
};

// Lay danh sach bai viet
export const getBaiViet = async () => {
  return apiCall('GET', API_ENDPOINTS.baiViet.list);
};

// Lay chi tiet bai viet
export const getBaiVietById = async (id) => {
  return apiCall('GET', API_ENDPOINTS.baiViet.detail(id));
};

// Them bai viet
export const createBaiViet = async (data) => {
  return apiCall('POST', API_ENDPOINTS.baiViet.create, data);
};

// Cap nhat bai viet
export const updateBaiViet = async (id, data) => {
  return apiCall('PUT', API_ENDPOINTS.baiViet.update(id), data);
};

// Xoa bai viet
export const deleteBaiViet = async (id) => {
  return apiCall('DELETE', API_ENDPOINTS.baiViet.delete(id));
};

console.log('API Base URL:', API_BASE_URL);
