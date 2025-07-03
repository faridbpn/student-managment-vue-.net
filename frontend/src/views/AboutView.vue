<template>
  <div class="about-container">
    <div class="about-content">
      <h1>Tentang Sistem Pendaftaran Mahasiswa</h1>
      <p>
        Sistem Pendaftaran Mahasiswa Baru adalah platform digital yang dirancang untuk 
        memudahkan proses pendaftaran mahasiswa baru secara online. Sistem ini menyediakan 
        fitur-fitur lengkap mulai dari pendaftaran, upload dokumen, hingga monitoring status 
        pendaftaran.
      </p>
      
      <div class="features">
        <h2>Fitur Utama</h2>
        <ul>
          <li>Pendaftaran online yang mudah dan cepat</li>
          <li>Upload foto dan dokumen digital</li>
          <li>Review dan approval oleh admin</li>
          <li>Dashboard real-time untuk monitoring status</li>
          <li>Sistem keamanan dengan JWT authentication</li>
        </ul>
      </div>
      
      <div class="tech-stack">
        <h2>Teknologi yang Digunakan</h2>
        <div class="tech-grid">
          <div class="tech-item">
            <strong>Frontend:</strong> Vue.js 3, Vite, Axios
          </div>
          <div class="tech-item">
            <strong>Backend:</strong> ASP.NET Core, Entity Framework
          </div>
          <div class="tech-item">
            <strong>Database:</strong> SQL Server
          </div>
          <div class="tech-item">
            <strong>Authentication:</strong> JWT Token
          </div>
        </div>
      </div>
      
      <router-link to="/" class="btn-back">Kembali ke Beranda</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: 'AboutView'
}
</script>

<style scoped>
.about-container {
  min-height: 100vh;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  padding: 40px 20px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.about-content {
  background: white;
  border-radius: 12px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
  padding: 40px;
  max-width: 800px;
  width: 100%;
}

.about-content h1 {
  color: #333;
  margin-bottom: 20px;
  text-align: center;
}

.about-content p {
  color: #666;
  line-height: 1.6;
  margin-bottom: 30px;
  text-align: justify;
}

.features {
  margin-bottom: 30px;
}

.features h2 {
  color: #333;
  margin-bottom: 15px;
}

.features ul {
  list-style: none;
  padding: 0;
}

.features li {
  color: #666;
  padding: 8px 0;
  padding-left: 20px;
  position: relative;
}

.features li:before {
  content: "✓";
  color: #28a745;
  font-weight: bold;
  position: absolute;
  left: 0;
}

.tech-stack {
  margin-bottom: 30px;
}

.tech-stack h2 {
  color: #333;
  margin-bottom: 15px;
}

.tech-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 15px;
}

.tech-item {
  background: #f8f9fa;
  padding: 15px;
  border-radius: 8px;
  border-left: 4px solid #667eea;
}

.tech-item strong {
  color: #333;
}

.btn-back {
  display: inline-block;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  padding: 12px 24px;
  border-radius: 8px;
  text-decoration: none;
  font-weight: 600;
  transition: transform 0.2s;
}

.btn-back:hover {
  transform: translateY(-2px);
}

@media (max-width: 768px) {
  .about-content {
    padding: 20px;
  }
  
  .tech-grid {
    grid-template-columns: 1fr;
  }
}
</style> 