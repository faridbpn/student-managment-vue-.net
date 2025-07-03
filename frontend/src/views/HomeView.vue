<template>
  <div class="home-container">
    <!-- Navigation -->
    <nav class="navbar">
      <div class="container">
        <div class="navbar-content">
          <router-link to="/" class="navbar-brand">
            🎓 Sistem Pendaftaran Mahasiswa
          </router-link>
          
          <div class="navbar-nav" :class="{ active: mobileMenuOpen }">
            <router-link to="/" class="nav-link">Beranda</router-link>
            <router-link to="/register" class="nav-link">Daftar</router-link>
            <router-link to="/login" class="nav-link">Login</router-link>
            <router-link to="/about" class="nav-link">Tentang</router-link>
          </div>
          
          <button 
            class="mobile-menu-toggle" 
            @click="toggleMobileMenu"
            aria-label="Toggle menu"
          >
            ☰
          </button>
        </div>
      </div>
    </nav>

    <!-- Hero Section -->
    <section class="hero-section">
      <div class="container">
        <div class="hero-content">
          <h1 class="hero-title">
            Selamat Datang di Sistem Pendaftaran Mahasiswa Baru
          </h1>
          <p class="hero-description">
            Platform pendaftaran mahasiswa baru yang mudah, cepat, dan terpercaya. 
            Daftar sekarang dan mulai perjalanan akademik Anda!
          </p>
          
          <div class="hero-actions">
            <router-link to="/register" class="btn btn-primary">
              📝 Daftar Sekarang
            </router-link>
            <router-link to="/login" class="btn btn-secondary">
              🔐 Sudah Punya Akun? Login
            </router-link>
          </div>
        </div>
      </div>
    </section>

    <!-- Features Section -->
    <section class="features-section">
      <div class="container">
        <h2 class="section-title">Fitur Utama</h2>
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
          <div class="feature-card">
            <div class="feature-icon">📝</div>
            <h3>Pendaftaran Online</h3>
            <p>Daftar mahasiswa baru secara online dengan mudah dan cepat</p>
          </div>
          
          <div class="feature-card">
            <div class="feature-icon">📸</div>
            <h3>Upload Foto</h3>
            <p>Upload foto 3x4 secara digital dengan format yang sesuai</p>
          </div>
          
          <div class="feature-card">
            <div class="feature-icon">👨‍💼</div>
            <h3>Review Admin</h3>
            <p>Proses review dan approval oleh admin yang terpercaya</p>
          </div>
          
          <div class="feature-card">
            <div class="feature-icon">📊</div>
            <h3>Dashboard Real-time</h3>
            <p>Pantau status pendaftaran Anda secara real-time</p>
          </div>
        </div>
      </div>
    </section>

    <!-- Process Section -->
    <section class="process-section">
      <div class="container">
        <h2 class="section-title">Cara Pendaftaran</h2>
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
          <div class="process-step">
            <div class="step-number">1</div>
            <h3>Isi Form Pendaftaran</h3>
            <p>Lengkapi data pribadi dan data orang tua dengan benar</p>
          </div>
          
          <div class="process-step">
            <div class="step-number">2</div>
            <h3>Upload Foto</h3>
            <p>Upload foto 3x4 dengan format JPG/PNG maksimal 2MB</p>
          </div>
          
          <div class="process-step">
            <div class="step-number">3</div>
            <h3>Review Admin</h3>
            <p>Admin akan memeriksa dan memverifikasi data Anda</p>
          </div>
          
          <div class="process-step">
            <div class="step-number">4</div>
            <h3>Status Approval</h3>
            <p>Pantau status pendaftaran melalui dashboard</p>
          </div>
        </div>
      </div>
    </section>

    <!-- Stats Section -->
    <section class="stats-section">
      <div class="container">
        <div class="grid grid-cols-1 md:grid-cols-3 gap-6">
          <div class="stat-card">
            <div class="stat-number">1000+</div>
            <div class="stat-label">Mahasiswa Terdaftar</div>
          </div>
          <div class="stat-card">
            <div class="stat-number">95%</div>
            <div class="stat-label">Tingkat Approval</div>
          </div>
          <div class="stat-card">
            <div class="stat-number">24/7</div>
            <div class="stat-label">Layanan Online</div>
          </div>
        </div>
      </div>
    </section>

    <!-- Footer -->
    <footer class="footer">
      <div class="container">
        <div class="footer-content">
          <div class="footer-section">
            <h3>🎓 Sistem Pendaftaran Mahasiswa</h3>
            <p>Platform pendaftaran mahasiswa baru yang modern dan terpercaya.</p>
          </div>
          <div class="footer-section">
            <h4>Link Cepat</h4>
            <router-link to="/register" class="footer-link">Daftar</router-link>
            <router-link to="/login" class="footer-link">Login</router-link>
            <router-link to="/about" class="footer-link">Tentang</router-link>
          </div>
          <div class="footer-section">
            <h4>Kontak</h4>
            <p>📧 info@pendaftaran.com</p>
            <p>📞 +62 123 456 789</p>
          </div>
        </div>
        <div class="footer-bottom">
          <p>&copy; 2024 Sistem Pendaftaran Mahasiswa Baru. All rights reserved.</p>
        </div>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  name: 'HomeView',
  data() {
    return {
      mobileMenuOpen: false
    }
  },
  methods: {
    toggleMobileMenu() {
      this.mobileMenuOpen = !this.mobileMenuOpen;
    }
  }
}
</script>

<style scoped>
.home-container {
  min-height: 100vh;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

/* Hero Section */
.hero-section {
  padding: 6rem 0 4rem;
  text-align: center;
  color: white;
}

.hero-title {
  font-size: 3rem;
  font-weight: 700;
  margin-bottom: 1.5rem;
  line-height: 1.2;
}

.hero-description {
  font-size: 1.25rem;
  margin-bottom: 3rem;
  opacity: 0.9;
  max-width: 600px;
  margin-left: auto;
  margin-right: auto;
}

.hero-actions {
  display: flex;
  gap: 1rem;
  justify-content: center;
  flex-wrap: wrap;
}

/* Features Section */
.features-section {
  background: white;
  padding: 5rem 0;
}

.section-title {
  text-align: center;
  font-size: 2.5rem;
  margin-bottom: 3rem;
  color: #1f2937;
}

.feature-card {
  text-align: center;
  padding: 2rem 1.5rem;
  background: #f8fafc;
  border-radius: 1rem;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
}

.feature-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
}

.feature-icon {
  font-size: 3rem;
  margin-bottom: 1rem;
}

.feature-card h3 {
  font-size: 1.25rem;
  margin-bottom: 1rem;
  color: #1f2937;
}

.feature-card p {
  color: #6b7280;
  line-height: 1.6;
}

/* Process Section */
.process-section {
  background: #f8fafc;
  padding: 5rem 0;
}

.process-step {
  text-align: center;
  padding: 2rem 1.5rem;
  background: white;
  border-radius: 1rem;
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.05);
  transition: transform 0.3s ease;
}

.process-step:hover {
  transform: translateY(-3px);
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
  font-size: 1.5rem;
  font-weight: bold;
  margin: 0 auto 1.5rem;
}

.process-step h3 {
  font-size: 1.25rem;
  margin-bottom: 1rem;
  color: #1f2937;
}

.process-step p {
  color: #6b7280;
  line-height: 1.6;
}

/* Stats Section */
.stats-section {
  background: white;
  padding: 4rem 0;
}

.stat-card {
  text-align: center;
  padding: 2rem;
  background: #f8fafc;
  border-radius: 1rem;
  transition: transform 0.3s ease;
}

.stat-card:hover {
  transform: translateY(-3px);
}

.stat-number {
  font-size: 3rem;
  font-weight: bold;
  color: #667eea;
  margin-bottom: 0.5rem;
}

.stat-label {
  font-size: 1.125rem;
  color: #6b7280;
  font-weight: 500;
}

/* Footer */
.footer {
  background: #1f2937;
  color: white;
  padding: 3rem 0 1rem;
}

.footer-content {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
  gap: 2rem;
  margin-bottom: 2rem;
}

.footer-section h3,
.footer-section h4 {
  margin-bottom: 1rem;
  color: white;
}

.footer-section p {
  color: #d1d5db;
  margin-bottom: 0.5rem;
}

.footer-link {
  display: block;
  color: #d1d5db;
  text-decoration: none;
  margin-bottom: 0.5rem;
  transition: color 0.2s ease;
}

.footer-link:hover {
  color: #667eea;
}

.footer-bottom {
  border-top: 1px solid #374151;
  padding-top: 1rem;
  text-align: center;
  color: #9ca3af;
}

/* Responsive Design */
@media (max-width: 768px) {
  .hero-title {
    font-size: 2rem;
  }
  
  .hero-description {
    font-size: 1.125rem;
  }
  
  .hero-actions {
    flex-direction: column;
    align-items: center;
  }
  
  .section-title {
    font-size: 2rem;
  }
  
  .feature-card,
  .process-step,
  .stat-card {
    padding: 1.5rem 1rem;
  }
  
  .stat-number {
    font-size: 2.5rem;
  }
  
  .footer-content {
    grid-template-columns: 1fr;
    text-align: center;
  }
}

@media (max-width: 480px) {
  .hero-section {
    padding: 4rem 0 2rem;
  }
  
  .hero-title {
    font-size: 1.75rem;
  }
  
  .features-section,
  .process-section,
  .stats-section {
    padding: 3rem 0;
  }
  
  .section-title {
    font-size: 1.75rem;
  }
}

/* Grid utilities */
.grid {
  display: grid;
  gap: 1.5rem;
}

.grid-cols-1 { grid-template-columns: repeat(1, 1fr); }

@media (min-width: 768px) {
  .md\:grid-cols-2 { grid-template-columns: repeat(2, 1fr); }
  .md\:grid-cols-3 { grid-template-columns: repeat(3, 1fr); }
}

@media (min-width: 1024px) {
  .lg\:grid-cols-4 { grid-template-columns: repeat(4, 1fr); }
}
</style> 