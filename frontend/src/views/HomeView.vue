<template>
  <div class="home-container">
    <nav class="navbar">
      <div class="nav-content">
        <h1>Sistem Pendaftaran Mahasiswa Baru</h1>
        <div class="nav-actions">
          <router-link to="/login" class="btn-login">Login</router-link>
          <router-link to="/register" class="btn-register">Daftar</router-link>
        </div>
      </div>
    </nav>

    <div class="hero-section">
      <div class="hero-content">
        <h2>Selamat Datang di Sistem Pendaftaran Mahasiswa Baru</h2>
        <p class="hero-description">
          Platform pendaftaran mahasiswa baru yang mudah, cepat, dan terpercaya. 
          Daftar sekarang dan mulai perjalanan akademik Anda!
        </p>
        
        <div class="hero-actions">
          <router-link to="/register" class="btn-primary">
            Daftar Sekarang
          </router-link>
          <router-link to="/login" class="btn-secondary">
            Sudah Punya Akun? Login
          </router-link>
        </div>
      </div>
    </div>

    <div class="features-section">
      <div class="container">
        <h3>Fitur Utama</h3>
        <div class="features-grid">
          <div class="feature-card">
            <div class="feature-icon">📝</div>
            <h4>Pendaftaran Online</h4>
            <p>Daftar mahasiswa baru secara online dengan mudah dan cepat</p>
          </div>
          
          <div class="feature-card">
            <div class="feature-icon">📸</div>
            <h4>Upload Foto</h4>
            <p>Upload foto 3x4 secara digital dengan format yang sesuai</p>
          </div>
          
          <div class="feature-card">
            <div class="feature-icon">👨‍💼</div>
            <h4>Review Admin</h4>
            <p>Proses review dan approval oleh admin yang terpercaya</p>
          </div>
          
          <div class="feature-card">
            <div class="feature-icon">📊</div>
            <h4>Dashboard Real-time</h4>
            <p>Pantau status pendaftaran Anda secara real-time</p>
          </div>
        </div>
      </div>
    </div>

    <div class="process-section">
      <div class="container">
        <h3>Cara Pendaftaran</h3>
        <div class="process-steps">
          <div class="step">
            <div class="step-number">1</div>
            <h4>Isi Form Pendaftaran</h4>
            <p>Lengkapi data pribadi dan data orang tua dengan benar</p>
          </div>
          
          <div class="step">
            <div class="step-number">2</div>
            <h4>Upload Foto</h4>
            <p>Upload foto 3x4 dengan format JPG/PNG maksimal 2MB</p>
          </div>
          
          <div class="step">
            <div class="step-number">3</div>
            <h4>Review Admin</h4>
            <p>Admin akan memeriksa dan memverifikasi data Anda</p>
          </div>
          
          <div class="step">
            <div class="step-number">4</div>
            <h4>Status Approval</h4>
            <p>Pantau status pendaftaran melalui dashboard</p>
          </div>
        </div>
      </div>
    </div>

    <footer class="footer">
      <div class="container">
        <p>&copy; 2024 Sistem Pendaftaran Mahasiswa Baru. All rights reserved.</p>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  name: 'HomeView'
}
</script>

<style scoped>
.home-container {
  min-height: 100vh;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

.navbar {
  background: rgba(255, 255, 255, 0.1);
  backdrop-filter: blur(10px);
  padding: 1rem 0;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000;
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
  color: white;
  font-size: 24px;
}

.nav-actions {
  display: flex;
  gap: 15px;
}

.btn-login,
.btn-register {
  padding: 10px 20px;
  border-radius: 8px;
  text-decoration: none;
  font-weight: 600;
  transition: all 0.3s;
}

.btn-login {
  background: rgba(255, 255, 255, 0.2);
  color: white;
  border: 1px solid rgba(255, 255, 255, 0.3);
}

.btn-login:hover {
  background: rgba(255, 255, 255, 0.3);
}

.btn-register {
  background: white;
  color: #667eea;
}

.btn-register:hover {
  background: #f8f9fa;
  transform: translateY(-2px);
}

.hero-section {
  padding: 120px 20px 80px;
  text-align: center;
  color: white;
}

.hero-content {
  max-width: 800px;
  margin: 0 auto;
}

.hero-content h2 {
  font-size: 48px;
  margin: 0 0 20px 0;
  font-weight: 700;
}

.hero-description {
  font-size: 20px;
  margin: 0 0 40px 0;
  opacity: 0.9;
  line-height: 1.6;
}

.hero-actions {
  display: flex;
  gap: 20px;
  justify-content: center;
  flex-wrap: wrap;
}

.btn-primary,
.btn-secondary {
  padding: 15px 30px;
  border-radius: 8px;
  text-decoration: none;
  font-weight: 600;
  font-size: 16px;
  transition: all 0.3s;
}

.btn-primary {
  background: white;
  color: #667eea;
}

.btn-primary:hover {
  background: #f8f9fa;
  transform: translateY(-2px);
}

.btn-secondary {
  background: rgba(255, 255, 255, 0.2);
  color: white;
  border: 2px solid rgba(255, 255, 255, 0.3);
}

.btn-secondary:hover {
  background: rgba(255, 255, 255, 0.3);
  transform: translateY(-2px);
}

.features-section {
  background: white;
  padding: 80px 20px;
}

.container {
  max-width: 1200px;
  margin: 0 auto;
}

.features-section h3 {
  text-align: center;
  font-size: 36px;
  margin: 0 0 60px 0;
  color: #333;
}

.features-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 30px;
}

.feature-card {
  text-align: center;
  padding: 40px 20px;
  background: #f8f9fa;
  border-radius: 12px;
  transition: transform 0.3s;
}

.feature-card:hover {
  transform: translateY(-5px);
}

.feature-icon {
  font-size: 48px;
  margin-bottom: 20px;
}

.feature-card h4 {
  font-size: 20px;
  margin: 0 0 15px 0;
  color: #333;
}

.feature-card p {
  color: #666;
  line-height: 1.6;
  margin: 0;
}

.process-section {
  background: #f5f7fa;
  padding: 80px 20px;
}

.process-section h3 {
  text-align: center;
  font-size: 36px;
  margin: 0 0 60px 0;
  color: #333;
}

.process-steps {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 30px;
}

.step {
  text-align: center;
  padding: 30px 20px;
  background: white;
  border-radius: 12px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.step-number {
  width: 60px;
  height: 60px;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  border-radius: 50%;
  display: flex;
  align-items: center;
  justify-content: center;
  font-size: 24px;
  font-weight: bold;
  margin: 0 auto 20px;
}

.step h4 {
  font-size: 18px;
  margin: 0 0 15px 0;
  color: #333;
}

.step p {
  color: #666;
  line-height: 1.6;
  margin: 0;
}

.footer {
  background: #333;
  color: white;
  text-align: center;
  padding: 30px 20px;
}

.footer p {
  margin: 0;
  opacity: 0.8;
}

@media (max-width: 768px) {
  .nav-content {
    flex-direction: column;
    gap: 15px;
  }
  
  .hero-content h2 {
    font-size: 32px;
  }
  
  .hero-description {
    font-size: 18px;
  }
  
  .hero-actions {
    flex-direction: column;
    align-items: center;
  }
  
  .features-grid,
  .process-steps {
    grid-template-columns: 1fr;
  }
}
</style> 