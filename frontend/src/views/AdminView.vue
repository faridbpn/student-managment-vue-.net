<template>
  <div class="admin-container">
    <nav class="navbar">
      <div class="nav-content">
        <h1>Admin Panel - Sistem Pendaftaran Mahasiswa</h1>
        <div class="nav-actions">
          <span class="welcome-text">Admin: {{ user?.username }}</span>
          <button @click="logout" class="btn-logout">Logout</button>
        </div>
      </div>
    </nav>

    <div class="admin-content">
      <div class="header-section">
        <h2>Daftar Pendaftar Mahasiswa</h2>
        <div class="stats">
          <div class="stat-item">
            <span class="stat-number">{{ stats.total }}</span>
            <span class="stat-label">Total</span>
          </div>
          <div class="stat-item">
            <span class="stat-number pending">{{ stats.pending }}</span>
            <span class="stat-label">Pending</span>
          </div>
          <div class="stat-item">
            <span class="stat-number approved">{{ stats.approved }}</span>
            <span class="stat-label">Approved</span>
          </div>
          <div class="stat-item">
            <span class="stat-number rejected">{{ stats.rejected }}</span>
            <span class="stat-label">Rejected</span>
          </div>
        </div>
      </div>

      <div v-if="loading" class="loading">
        <div class="spinner"></div>
        <p>Memuat data pendaftar...</p>
      </div>

      <div v-else-if="error" class="error-container">
        <h3>Terjadi Kesalahan</h3>
        <p>{{ error }}</p>
        <button @click="loadStudents" class="btn-retry">Coba Lagi</button>
      </div>

      <div v-else class="students-table">
        <div v-if="students.length === 0" class="empty-state">
          <p>Belum ada pendaftar mahasiswa.</p>
        </div>

        <div v-else class="table-container">
          <table>
            <thead>
              <tr>
                <th>Foto</th>
                <th>Nama</th>
                <th>NIM</th>
                <th>Email</th>
                <th>Status</th>
                <th>Orang Tua</th>
                <th>Aksi</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="student in students" :key="student.id" class="student-row">
                <td class="photo-cell">
                  <img 
                    v-if="student.photoPath" 
                    :src="`http://localhost:5000/${student.photoPath}`" 
                    :alt="student.fullName"
                    class="student-photo"
                  />
                  <div v-else class="no-photo">No Photo</div>
                </td>
                <td>{{ student.fullName }}</td>
                <td>{{ student.nim }}</td>
                <td>{{ student.email }}</td>
                <td>
                  <span class="status-badge" :class="getStatusClass(student.status)">
                    {{ getStatusText(student.status) }}
                  </span>
                </td>
                <td class="parent-info">
                  <div><strong>Ayah:</strong> {{ student.parent?.fatherName }}</div>
                  <div><strong>Ibu:</strong> {{ student.parent?.motherName }}</div>
                  <div><strong>HP:</strong> {{ student.parent?.phone }}</div>
                </td>
                <td class="actions">
                  <div v-if="student.status === 'Pending'" class="action-buttons">
                    <button 
                      @click="approveStudent(student.id)" 
                      :disabled="processing === student.id"
                      class="btn-approve"
                    >
                      {{ processing === student.id ? 'Processing...' : 'Approve' }}
                    </button>
                    <button 
                      @click="rejectStudent(student.id)" 
                      :disabled="processing === student.id"
                      class="btn-reject"
                    >
                      {{ processing === student.id ? 'Processing...' : 'Reject' }}
                    </button>
                  </div>
                  <span v-else class="status-text">
                    {{ student.status === 'Approved' ? 'Sudah Disetujui' : 'Sudah Ditolak' }}
                  </span>
                </td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { studentService } from '../services/student.js'
import { authService } from '../services/auth.js'

export default {
  name: 'AdminView',
  data() {
    return {
      loading: true,
      error: '',
      students: [],
      user: null,
      processing: null
    }
  },
  computed: {
    stats() {
      const total = this.students.length;
      const pending = this.students.filter(s => s.status === 'Pending').length;
      const approved = this.students.filter(s => s.status === 'Approved').length;
      const rejected = this.students.filter(s => s.status === 'Rejected').length;
      
      return { total, pending, approved, rejected };
    }
  },
  async mounted() {
    this.user = authService.getUser();
    await this.loadStudents();
  },
  methods: {
    async loadStudents() {
      try {
        this.loading = true;
        this.error = '';
        this.students = await studentService.getAllStudents();
      } catch (error) {
        console.error('Error loading students:', error);
        this.error = 'Gagal memuat data pendaftar. Silakan coba lagi.';
      } finally {
        this.loading = false;
      }
    },
    
    async approveStudent(id) {
      try {
        this.processing = id;
        await studentService.approveStudent(id);
        
        // Update local data
        const student = this.students.find(s => s.id === id);
        if (student) {
          student.status = 'Approved';
        }
        
        alert('Pendaftaran berhasil disetujui!');
      } catch (error) {
        console.error('Error approving student:', error);
        alert('Gagal menyetujui pendaftaran. Silakan coba lagi.');
      } finally {
        this.processing = null;
      }
    },
    
    async rejectStudent(id) {
      try {
        this.processing = id;
        await studentService.rejectStudent(id);
        
        // Update local data
        const student = this.students.find(s => s.id === id);
        if (student) {
          student.status = 'Rejected';
        }
        
        alert('Pendaftaran berhasil ditolak!');
      } catch (error) {
        console.error('Error rejecting student:', error);
        alert('Gagal menolak pendaftaran. Silakan coba lagi.');
      } finally {
        this.processing = null;
      }
    },
    
    getStatusClass(status) {
      switch (status) {
        case 'Approved': return 'status-approved';
        case 'Rejected': return 'status-rejected';
        case 'Pending': return 'status-pending';
        default: return 'status-pending';
      }
    },
    
    getStatusText(status) {
      switch (status) {
        case 'Approved': return 'Disetujui';
        case 'Rejected': return 'Ditolak';
        case 'Pending': return 'Menunggu Review';
        default: return 'Tidak Diketahui';
      }
    },
    
    logout() {
      authService.logout();
      this.$router.push('/login');
    }
  }
}
</script>

<style scoped>
.admin-container {
  min-height: 100vh;
  background: #f5f7fa;
}

.navbar {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  padding: 1rem 0;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

.nav-content {
  max-width: 1400px;
  margin: 0 auto;
  padding: 0 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.nav-content h1 {
  margin: 0;
  font-size: 24px;
}

.nav-actions {
  display: flex;
  align-items: center;
  gap: 20px;
}

.welcome-text {
  font-weight: 500;
}

.btn-logout {
  background: rgba(255, 255, 255, 0.2);
  border: 1px solid rgba(255, 255, 255, 0.3);
  color: white;
  padding: 8px 16px;
  border-radius: 6px;
  cursor: pointer;
  transition: background 0.3s;
}

.btn-logout:hover {
  background: rgba(255, 255, 255, 0.3);
}

.admin-content {
  max-width: 1400px;
  margin: 40px auto;
  padding: 0 20px;
}

.header-section {
  background: white;
  border-radius: 12px;
  padding: 30px;
  margin-bottom: 30px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.header-section h2 {
  margin: 0 0 20px 0;
  color: #333;
}

.stats {
  display: flex;
  gap: 30px;
  flex-wrap: wrap;
}

.stat-item {
  text-align: center;
  padding: 20px;
  background: #f8f9fa;
  border-radius: 8px;
  min-width: 100px;
}

.stat-number {
  display: block;
  font-size: 32px;
  font-weight: bold;
  color: #667eea;
}

.stat-number.pending {
  color: #ffc107;
}

.stat-number.approved {
  color: #28a745;
}

.stat-number.rejected {
  color: #dc3545;
}

.stat-label {
  color: #666;
  font-size: 14px;
}

.loading {
  text-align: center;
  padding: 60px 20px;
  background: white;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.spinner {
  border: 4px solid #f3f3f3;
  border-top: 4px solid #667eea;
  border-radius: 50%;
  width: 40px;
  height: 40px;
  animation: spin 1s linear infinite;
  margin: 0 auto 20px;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

.error-container {
  text-align: center;
  padding: 40px 20px;
  background: white;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.btn-retry {
  background: #667eea;
  color: white;
  border: none;
  padding: 12px 24px;
  border-radius: 8px;
  cursor: pointer;
  margin-top: 20px;
}

.students-table {
  background: white;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.empty-state {
  text-align: center;
  padding: 60px 20px;
  color: #666;
}

.table-container {
  overflow-x: auto;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th {
  background: #f8f9fa;
  padding: 15px;
  text-align: left;
  font-weight: 600;
  color: #333;
  border-bottom: 2px solid #dee2e6;
}

td {
  padding: 15px;
  border-bottom: 1px solid #dee2e6;
  vertical-align: top;
}

.student-row:hover {
  background: #f8f9fa;
}

.photo-cell {
  width: 80px;
}

.student-photo {
  width: 60px;
  height: 60px;
  border-radius: 50%;
  object-fit: cover;
}

.no-photo {
  width: 60px;
  height: 60px;
  border-radius: 50%;
  background: #f8f9fa;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 12px;
  color: #666;
  border: 1px solid #dee2e6;
}

.status-badge {
  display: inline-block;
  padding: 4px 8px;
  border-radius: 12px;
  font-size: 12px;
  font-weight: 600;
}

.status-approved {
  background: #d4edda;
  color: #155724;
}

.status-rejected {
  background: #f8d7da;
  color: #721c24;
}

.status-pending {
  background: #fff3cd;
  color: #856404;
}

.parent-info {
  font-size: 14px;
  line-height: 1.4;
}

.parent-info div {
  margin-bottom: 4px;
}

.actions {
  width: 150px;
}

.action-buttons {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.btn-approve {
  background: #28a745;
  color: white;
  border: none;
  padding: 8px 12px;
  border-radius: 6px;
  cursor: pointer;
  font-size: 12px;
  font-weight: 600;
}

.btn-approve:hover:not(:disabled) {
  background: #218838;
}

.btn-reject {
  background: #dc3545;
  color: white;
  border: none;
  padding: 8px 12px;
  border-radius: 6px;
  cursor: pointer;
  font-size: 12px;
  font-weight: 600;
}

.btn-reject:hover:not(:disabled) {
  background: #c82333;
}

.btn-approve:disabled,
.btn-reject:disabled {
  opacity: 0.6;
  cursor: not-allowed;
}

.status-text {
  font-size: 12px;
  color: #666;
  font-style: italic;
}

@media (max-width: 768px) {
  .nav-content {
    flex-direction: column;
    gap: 15px;
  }
  
  .stats {
    justify-content: center;
  }
  
  .table-container {
    font-size: 14px;
  }
  
  th, td {
    padding: 10px 8px;
  }
}
</style> 