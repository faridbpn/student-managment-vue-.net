<template>
  <div class="register-container">
    <div class="register-card">
      <h2>Pendaftaran Mahasiswa Baru</h2>
      
      <form @submit.prevent="handleSubmit" class="register-form">
        <!-- Data Pribadi -->
        <div class="form-section">
          <h3>Data Pribadi</h3>
          
          <div class="form-group">
            <label for="fullName">Nama Lengkap *</label>
            <input 
              type="text" 
              id="fullName" 
              v-model="form.fullName" 
              required
              placeholder="Masukkan nama lengkap"
            />
          </div>

          <div class="form-group">
            <label for="nim">NIM *</label>
            <input 
              type="text" 
              id="nim" 
              v-model="form.nim" 
              required
              placeholder="Masukkan NIM"
            />
          </div>

          <div class="form-group">
            <label for="email">Email *</label>
            <input 
              type="email" 
              id="email" 
              v-model="form.email" 
              required
              placeholder="Masukkan email"
            />
          </div>

          <div class="form-group">
            <label for="username">Username *</label>
            <input 
              type="text" 
              id="username" 
              v-model="form.username" 
              required
              placeholder="Masukkan username"
            />
          </div>

          <div class="form-group">
            <label for="password">Password *</label>
            <input 
              type="password" 
              id="password" 
              v-model="form.password" 
              required
              placeholder="Masukkan password"
            />
          </div>

          <div class="form-group">
            <label for="photo">Foto 3x4 *</label>
            <input 
              type="file" 
              id="photo" 
              @change="handlePhotoChange" 
              accept="image/*"
              required
            />
            <small>Format: JPG, PNG. Maksimal 2MB</small>
          </div>
        </div>

        <!-- Data Orang Tua -->
        <div class="form-section">
          <h3>Data Orang Tua</h3>
          
          <div class="form-group">
            <label for="fatherName">Nama Ayah *</label>
            <input 
              type="text" 
              id="fatherName" 
              v-model="form.parent.fatherName" 
              required
              placeholder="Masukkan nama ayah"
            />
          </div>

          <div class="form-group">
            <label for="motherName">Nama Ibu *</label>
            <input 
              type="text" 
              id="motherName" 
              v-model="form.parent.motherName" 
              required
              placeholder="Masukkan nama ibu"
            />
          </div>

          <div class="form-group">
            <label for="address">Alamat *</label>
            <textarea 
              id="address" 
              v-model="form.parent.address" 
              required
              placeholder="Masukkan alamat lengkap"
              rows="3"
            ></textarea>
          </div>

          <div class="form-group">
            <label for="phone">No. HP *</label>
            <input 
              type="tel" 
              id="phone" 
              v-model="form.parent.phone" 
              required
              placeholder="Masukkan nomor HP"
            />
          </div>
        </div>

        <div class="form-actions">
          <button type="submit" :disabled="loading" class="btn-submit">
            {{ loading ? 'Mendaftar...' : 'Daftar Sekarang' }}
          </button>
        </div>
      </form>

      <div class="login-link">
        Sudah punya akun? <router-link to="/login">Login di sini</router-link>
      </div>
    </div>
  </div>
</template>

<script>
import { studentService } from '../services/student.js'

export default {
  name: 'RegisterView',
  data() {
    return {
      loading: false,
      form: {
        fullName: '',
        nim: '',
        email: '',
        username: '',
        password: '',
        photo: null,
        parent: {
          fatherName: '',
          motherName: '',
          address: '',
          phone: ''
        }
      }
    }
  },
  methods: {
    handlePhotoChange(event) {
      const file = event.target.files[0];
      if (file) {
        // Validasi ukuran file (max 2MB)
        if (file.size > 2 * 1024 * 1024) {
          alert('Ukuran file terlalu besar. Maksimal 2MB.');
          event.target.value = '';
          return;
        }
        this.form.photo = file;
      }
    },
    
    async handleSubmit() {
      try {
        this.loading = true;
        
        const formData = new FormData();
        formData.append('FullName', this.form.fullName);
        formData.append('NIM', this.form.nim);
        formData.append('Email', this.form.email);
        formData.append('Username', this.form.username);
        formData.append('Password', this.form.password);
        formData.append('Photo', this.form.photo);
        
        // Data orang tua
        formData.append('Parent.FatherName', this.form.parent.fatherName);
        formData.append('Parent.MotherName', this.form.parent.motherName);
        formData.append('Parent.Address', this.form.parent.address);
        formData.append('Parent.Phone', this.form.parent.phone);
        
        await studentService.register(formData);
        
        alert('Pendaftaran berhasil! Silakan login setelah admin menyetujui pendaftaran Anda.');
        this.$router.push('/login');
        
      } catch (error) {
        console.error('Error registering:', error);
        alert('Terjadi kesalahan saat mendaftar. Silakan coba lagi.');
      } finally {
        this.loading = false;
      }
    }
  }
}
</script>

<style scoped>
.register-container {
  min-height: 100vh;
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  padding: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.register-card {
  background: white;
  border-radius: 12px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
  padding: 40px;
  width: 100%;
  max-width: 600px;
}

.register-card h2 {
  text-align: center;
  color: #333;
  margin-bottom: 30px;
  font-size: 28px;
}

.form-section {
  margin-bottom: 30px;
}

.form-section h3 {
  color: #555;
  border-bottom: 2px solid #667eea;
  padding-bottom: 10px;
  margin-bottom: 20px;
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

.form-group input,
.form-group textarea {
  width: 100%;
  padding: 12px;
  border: 2px solid #e1e5e9;
  border-radius: 8px;
  font-size: 16px;
  transition: border-color 0.3s;
}

.form-group input:focus,
.form-group textarea:focus {
  outline: none;
  border-color: #667eea;
}

.form-group small {
  color: #666;
  font-size: 12px;
  margin-top: 5px;
  display: block;
}

.form-actions {
  text-align: center;
  margin-top: 30px;
}

.btn-submit {
  background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
  color: white;
  border: none;
  padding: 15px 40px;
  border-radius: 8px;
  font-size: 16px;
  font-weight: 600;
  cursor: pointer;
  transition: transform 0.2s;
}

.btn-submit:hover:not(:disabled) {
  transform: translateY(-2px);
}

.btn-submit:disabled {
  opacity: 0.7;
  cursor: not-allowed;
}

.login-link {
  text-align: center;
  margin-top: 20px;
  color: #666;
}

.login-link a {
  color: #667eea;
  text-decoration: none;
  font-weight: 600;
}

.login-link a:hover {
  text-decoration: underline;
}
</style>
