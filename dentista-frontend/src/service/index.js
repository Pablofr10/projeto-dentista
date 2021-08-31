import axios from "axios";

const token =
  "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI3YmQ3Mzk4Zi00ZjQ3LTRlNDktOTkwNS03MGE0ZjU1MDE3NjEiLCJ1bmlxdWVfbmFtZSI6InBhYmxvcmYuYXJhdWpvQGdtYWlsLmNvbSIsInJvbGUiOlsiUEFDSUVOVEUxIiwiQWRtaW5pc3RyYWRvciJdLCJuYmYiOjE2MzAzNzk4NDQsImV4cCI6MTYzMDQ2NjI0NCwiaWF0IjoxNjMwMzc5ODQ0fQ.wke-u9XvsrRZneja5S5xI_3gweGo58aebRERfbsHJHyNrywKwMW05wvFxb60cCHKMZEPupidJDUVl5Q26dr7BA";

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
