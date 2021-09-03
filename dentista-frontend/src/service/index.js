import axios from "axios";

const token =
  "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI3YmQ3Mzk4Zi00ZjQ3LTRlNDktOTkwNS03MGE0ZjU1MDE3NjEiLCJ1bmlxdWVfbmFtZSI6InBhYmxvcmYuYXJhdWpvQGdtYWlsLmNvbSIsInJvbGUiOlsiUEFDSUVOVEUxIiwiQWRtaW5pc3RyYWRvciJdLCJuYmYiOjE2MzA2MTk2MDAsImV4cCI6MTYzMDcwNjAwMCwiaWF0IjoxNjMwNjE5NjAwfQ.sSjFKx9kgOFm33sQwSRO3mVMeAdM7AZCEvdp71sM4QWMQUp0z79gu1x4dFp8o49sr8boESs2s8AfbOBg1cZRxA";

const axiosInstance = axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 1000,
  headers: { Authorization: `Bearer ${token}` }
});

const api = {
  get(endpoint) {
    return axiosInstance.get(endpoint);
  },
  post(endpoint, body) {
    return axiosInstance.post(endpoint, body);
  },
  delete(endpoint) {
    return axiosInstance.delete(endpoint);
  },
  put(endpoint, body) {
    return axiosInstance.put(endpoint, body);
  }
};

export default api;
