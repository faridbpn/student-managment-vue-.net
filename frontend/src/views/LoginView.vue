<template>
  <div class="login-container">
    <!-- Navigation -->
    <nav class="navbar">
      <div class="container">
        <div class="navbar-content">
          <router-link to="/" class="navbar-brand">
            🎓 Sistem Pendaftaran Mahasiswa
          </router-link>
          <router-link to="/register" class="nav-link">Belum punya akun? Daftar</router-link>
        </div>
      </div>
    </nav>

    <div class="login-content">
      <div class="container">
        <div class="login-card">
          <div class="card-header">
            <h1 class="text-center">🔐 Login</h1>
            <p class="text-center text-muted">Masuk ke akun Anda</p>
          </div>

          <div class="card-body">
            <form @submit.prevent="handleSubmit" class="login-form">
              <div class="form-group">
                <label for="username" class="form-label">👤 Username</label>
                <input 
                  type="text" 
                  id="username" 
                  v-model="form.username" 
                  class="form-input"
                  required
                  placeholder="Masukkan username"
                />
              </div>

              <div class="form-group">
                <label for="password" class="form-label">🔒 Password</label>
                <input 
                  type="password" 
                  id="password" 
                  v-model="form.password" 
                  class="form-input"
                  required
                  placeholder="Masukkan password"
                />
              </div>

              <!-- Error Message -->
              <div v-if="error" class="error-message">
                <span class="error-icon">⚠️</span>
                {{ error }}
              </div>

              <!-- Submit Button -->
              <div class="form-actions">
                <button type="submit" :disabled="loading" class="btn btn-primary btn-large">
                  <span v-if="loading" class="spinner-small"></span>
                  {{ loading ? 'Login...' : '🔐 Login' }}
                </button>
              </div>
            </form>
          </div>

          <div class="card-footer">
            <p class="text-center">
              Belum punya akun? 
              <router-link to="/register" class="text-primary">Daftar di sini</router-link>
            </p>
            
            <!-- Demo Credentials -->
            <div class="demo-credentials">
              <h4>Demo Credentials:</h4>
              <div class="credential-item">
                <strong>Admin:</strong> username: admin, password: admin123
              </div>
              <div class="credential-item">
                <strong>Mahasiswa:</strong> Daftar dulu di halaman register
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { authService } from '../services/auth.js'

export default {
  name: 'LoginView',
  data() {
    return {
      loading: false,
      error: '',
      form: {
        username: '',
        password: ''
      }
    }
  },
  methods: {
    async handleSubmit() {
      try {
        this.loading = true;
        this.error = '';
        
        const response = await authService.login(this.form);
        
        // Redirect berdasarkan role
        if (response.user.role === 'Admin') {
          this.$router.push('/admin');
        } else {
          this.$router.push('/dashboard');
        }
        
      } catch (error) {
        console.error('Login error:', error);
        this.error = error.response?.data?.message || 'Username atau password salah';
      } finally {
        this.loading = false;
      }
    }
  }
}
</script>

<style scoped>
.login-container {
  min-height: 100vh;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

.login-content {
  padding: 2rem 0;
  display: flex;
  align-items: center;
  min-height: calc(100vh - 80px);
}

.login-card {
  max-width: 500px;
  margin: 0 auto;
  background: white;
  border-radius: 1rem;
  box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04);
  overflow: hidden;
  width: 100%;
}

.card-header {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  padding: 2rem;
  text-align: center;
}

.card-header h1 {
  margin: 0 0 0.5rem 0;
  font-size: 2rem;
}

.card-header p {
  margin: 0;
  opacity: 0.9;
}

.card-body {
  padding: 2rem;
}

.form-group {
  margin-bottom: 1.5rem;
}

.form-label {
  display: block;
  margin-bottom: 0.5rem;
  font-weight: 500;
  color: #374151;
  font-size: 0.875rem;
}

.form-input {
  width: 100%;
  padding: 0.75rem 1rem;
  border: 2px solid #e5e7eb;
  border-radius: 0.5rem;
  font-size: 1rem;
  transition: border-color 0.2s ease-in-out;
  background: white;
}

.form-input:focus {
  outline: none;
  border-color: #667eea;
  box-shadow: 0 0 0 3px rgba(102, 126, 234, 0.1);
}

.form-input::placeholder {
  color: #9ca3af;
}

.error-message {
  background: #fef2f2;
  color: #dc2626;
  padding: 1rem;
  border-radius: 0.5rem;
  border: 1px solid #fecaca;
  margin-bottom: 1.5rem;
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.error-icon {
  font-size: 1.25rem;
}

.form-actions {
  text-align: center;
  margin-top: 2rem;
}

.btn-large {
  padding: 1rem 2rem;
  font-size: 1rem;
  min-width: 200px;
}

.spinner-small {
  width: 16px;
  height: 16px;
  border: 2px solid transparent;
  border-top: 2px solid currentColor;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  margin-right: 0.5rem;
}

.card-footer {
  background: #f8fafc;
  padding: 1.5rem 2rem;
  text-align: center;
  border-top: 1px solid #e5e7eb;
}

.text-primary {
  color: #667eea;
  text-decoration: none;
  font-weight: 500;
}

.text-primary:hover {
  text-decoration: underline;
}

.demo-credentials {
  margin-top: 1.5rem;
  padding: 1rem;
  background: #f0f9ff;
  border: 1px solid #bae6fd;
  border-radius: 0.5rem;
  text-align: left;
}

.demo-credentials h4 {
  margin: 0 0 1rem 0;
  color: #0369a1;
  font-size: 0.875rem;
  text-transform: uppercase;
  letter-spacing: 0.05em;
}

.credential-item {
  margin-bottom: 0.5rem;
  font-size: 0.875rem;
  color: #0c4a6e;
}

.credential-item:last-child {
  margin-bottom: 0;
}

.credential-item strong {
  color: #0369a1;
}

/* Responsive Design */
@media (max-width: 768px) {
  .login-content {
    padding: 1rem 0;
    align-items: flex-start;
  }
  
  .login-card {
    margin: 1rem;
  }
  
  .card-header {
    padding: 1.5rem;
  }
  
  .card-header h1 {
    font-size: 1.5rem;
  }
  
  .card-body {
    padding: 1.5rem;
  }
  
  .card-footer {
    padding: 1rem 1.5rem;
  }
  
  .btn-large {
    width: 100%;
    min-width: auto;
  }
}

@media (max-width: 480px) {
  .login-content {
    padding: 0.5rem 0;
  }
  
  .login-card {
    margin: 0.5rem;
  }
  
  .card-header {
    padding: 1rem;
  }
  
  .card-body {
    padding: 1rem;
  }
  
  .card-footer {
    padding: 1rem;
  }
  
  .demo-credentials {
    margin-top: 1rem;
    padding: 0.75rem;
  }
}
</style> 