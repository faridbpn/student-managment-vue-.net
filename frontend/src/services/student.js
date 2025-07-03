import api from './api';

export const studentService = {
  async register(formData) {
    const response = await api.post('/student', formData, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },
    });
    return response.data;
  },

  async getDashboard() {
    const response = await api.get('/student/dashboard');
    return response.data;
  },

  async getAllStudents() {
    const response = await api.get('/admin/students');
    return response.data;
  },

  async approveStudent(id) {
    const response = await api.put(`/admin/students/${id}/approve`);
    return response.data;
  },

  async rejectStudent(id) {
    const response = await api.put(`/admin/students/${id}/reject`);
    return response.data;
  }
}; 