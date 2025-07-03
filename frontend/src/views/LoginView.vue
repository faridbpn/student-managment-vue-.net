<template>
  <div class="login-container">
    <div class="login-card">
      <h2>Login</h2>
      
      <form @submit.prevent="handleSubmit" class="login-form">
        <div class="form-group">
          <label for="username">Username</label>
          <input 
            type="text" 
            id="username" 
            v-model="form.username" 
            required
            placeholder="Masukkan username"
          />
        </div>

        <div class="form-group">
          <label for="password">Password</label>
          <input 
            type="password" 
            id="password" 
            v-model="form.password" 
            required
            placeholder="Masukkan password"
          />
        </div>

        <div class="form-actions">
          <button type="submit" :disabled="loading" class="btn-login">
            {{ loading ? 'Login...' : 'Login' }}
          </button>
        </div>
      </form>

      <div class="register-link">
        Belum punya akun? <router-link to="/register">Daftar di sini</router-link>
      </div>

      <div v-if="error" class="error-message">
        {{ error }}
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
  padding: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.login-card {
  background: white;
  border-radius: 12px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
  padding: 40px;
  width: 100%;
  max-width: 400px;
}

.login-card h2 {
  text-align: center;
  color: #333;
  margin-bottom: 30px;
  font-size: 28px;
}

.form-group {
  margin-bottom: 20px;
}

.form-group label {
  display: block;
  margin-bottom: 8px;
  font-weight: 600;
  color: #333;
}

.form-group input {
  width: 100%;
  padding: 12px;
  border: 2px solid #e1e5e9;
  border-radius: 8px;
  font-size: 16px;
  transition: border-color 0.3s;
}

.form-group input:focus {
  outline: none;
  border-color: #667eea;
}

.form-actions {
  text-align: center;
  margin-top: 30px;
}

.btn-login {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  border: none;
  padding: 15px 40px;
  border-radius: 8px;
  font-size: 16px;
  font-weight: 600;
  cursor: pointer;
  transition: transform 0.2s;
  width: 100%;
}

.btn-login:hover:not(:disabled) {
  transform: translateY(-2px);
}

.btn-login:disabled {
  opacity: 0.7;
  cursor: not-allowed;
}

.register-link {
  text-align: center;
  margin-top: 20px;
  color: #666;
}

.register-link a {
  color: #667eea;
  text-decoration: none;
  font-weight: 600;
}

.register-link a:hover {
  text-decoration: underline;
}

.error-message {
  background: #fee;
  color: #c33;
  padding: 12px;
  border-radius: 8px;
  margin-top: 20px;
  text-align: center;
  border: 1px solid #fcc;
}
</style> 