<template>
  <div class="dashboard-container">
    <nav class="navbar">
      <div class="nav-content">
        <h1>Sistem Pendaftaran Mahasiswa</h1>
        <div class="nav-actions">
          <span class="welcome-text">Selamat datang, {{ user?.username }}</span>
          <button @click="logout" class="btn-logout">Logout</button>
        </div>
      </div>
    </nav>

    <div class="dashboard-content">
      <div v-if="loading" class="loading">
        <div class="spinner"></div>
        <p>Memuat data...</p>
      </div>

      <div v-else-if="error" class="error-container">
        <h3>Terjadi Kesalahan</h3>
        <p>{{ error }}</p>
        <button @click="loadDashboard" class="btn-retry">Coba Lagi</button>
      </div>

      <div v-else class="dashboard-card">
        <div class="profile-section">
          <div class="profile-photo">
            <img 
              v-if="student?.photoPath" 
              :src="`http://localhost:5000/${student.photoPath}`" 
              :alt="student?.fullName"
              class="student-photo"
            />
            <div v-else class="no-photo">
              <span>No Photo</span>
            </div>
          </div>
          
          <div class="profile-info">
            <h2>{{ student?.fullName || 'Nama tidak tersedia' }}</h2>
            <p class="nim">{{ student?.nim || 'NIM tidak tersedia' }}</p>
            <p class="email">{{ student?.email || 'Email tidak tersedia' }}</p>
          </div>
        </div>

        <div class="status-section">
          <h3>Status Pendaftaran</h3>
          <div class="status-badge" :class="getStatusClass(student?.status)">
            {{ getStatusText(student?.status) }}
          </div>
          
          <div class="status-message">
            <p v-if="student?.status === 'Pending'">
              Pendaftaran Anda sedang dalam proses review oleh admin. 
              Silakan tunggu notifikasi selanjutnya.
            </p>
            <p v-else-if="student?.status === 'Approved'">
              Selamat! Pendaftaran Anda telah disetujui. 
              Anda dapat mengakses semua fitur mahasiswa.
            </p>
            <p v-else-if="student?.status === 'Rejected'">
              Maaf, pendaftaran Anda ditolak. 
              Silakan hubungi admin untuk informasi lebih lanjut.
            </p>
          </div>
        </div>

        <div v-if="student?.parent" class="parent-section">
          <h3>Data Orang Tua</h3>
          <div class="parent-info">
            <div class="parent-item">
              <strong>Ayah:</strong> {{ student.parent.fatherName }}
            </div>
            <div class="parent-item">
              <strong>Ibu:</strong> {{ student.parent.motherName }}
            </div>
            <div class="parent-item">
              <strong>Alamat:</strong> {{ student.parent.address }}
            </div>
            <div class="parent-item">
              <strong>No. HP:</strong> {{ student.parent.phone }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { studentService } from '../services/student.js'
import { authService } from '../services/auth.js'

export default {
  name: 'DashboardView',
  data() {
    return {
      loading: true,
      error: '',
      student: null,
      user: null
    }
  },
  async mounted() {
    this.user = authService.getUser();
    await this.loadDashboard();
  },
  methods: {
    async loadDashboard() {
      try {
        this.loading = true;
        this.error = '';
        this.student = await studentService.getDashboard();
      } catch (error) {
        console.error('Error loading dashboard:', error);
        this.error = 'Gagal memuat data dashboard. Silakan coba lagi.';
      } finally {
        this.loading = false;
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
.dashboard-container {
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
  max-width: 1200px;
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

.dashboard-content {
  max-width: 800px;
  margin: 40px auto;
  padding: 0 20px;
}

.loading {
  text-align: center;
  padding: 60px 20px;
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

.dashboard-card {
  background: white;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.profile-section {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  padding: 40px;
  display: flex;
  align-items: center;
  gap: 30px;
}

.profile-photo {
  flex-shrink: 0;
}

.student-photo {
  width: 120px;
  height: 120px;
  border-radius: 50%;
  object-fit: cover;
  border: 4px solid rgba(255, 255, 255, 0.3);
}

.no-photo {
  width: 120px;
  height: 120px;
  border-radius: 50%;
  background: rgba(255, 255, 255, 0.2);
  display: flex;
  align-items: center;
  justify-content: center;
  border: 4px solid rgba(255, 255, 255, 0.3);
}

.profile-info h2 {
  margin: 0 0 10px 0;
  font-size: 28px;
}

.profile-info .nim {
  margin: 5px 0;
  opacity: 0.9;
  font-size: 18px;
}

.profile-info .email {
  margin: 5px 0;
  opacity: 0.8;
}

.status-section {
  padding: 30px 40px;
  border-bottom: 1px solid #eee;
}

.status-section h3 {
  margin: 0 0 20px 0;
  color: #333;
}

.status-badge {
  display: inline-block;
  padding: 8px 16px;
  border-radius: 20px;
  font-weight: 600;
  font-size: 14px;
  margin-bottom: 15px;
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

.status-message {
  color: #666;
  line-height: 1.6;
}

.parent-section {
  padding: 30px 40px;
}

.parent-section h3 {
  margin: 0 0 20px 0;
  color: #333;
}

.parent-info {
  display: grid;
  gap: 15px;
}

.parent-item {
  padding: 15px;
  background: #f8f9fa;
  border-radius: 8px;
  border-left: 4px solid #667eea;
}

.parent-item strong {
  color: #333;
}

@media (max-width: 768px) {
  .nav-content {
    flex-direction: column;
    gap: 15px;
  }
  
  .profile-section {
    flex-direction: column;
    text-align: center;
  }
  
  .profile-info h2 {
    font-size: 24px;
  }
}
</style> 