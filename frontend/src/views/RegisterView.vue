<template>
  <div class="register-container">
    <!-- Navigation -->
    <nav class="navbar">
      <div class="container">
        <div class="navbar-content">
          <router-link to="/" class="navbar-brand">
            🎓 Sistem Pendaftaran Mahasiswa
          </router-link>
          <router-link to="/login" class="nav-link">Sudah punya akun? Login</router-link>
        </div>
      </div>
    </nav>

    <div class="register-content">
      <div class="container">
        <div class="register-card">
          <div class="card-header">
            <h1 class="text-center">📝 Pendaftaran Mahasiswa Baru</h1>
            <p class="text-center text-muted">Lengkapi data diri Anda dengan benar</p>
          </div>

          <div class="card-body">
            <form @submit.prevent="handleSubmit" class="register-form">
              <!-- Data Pribadi -->
              <div class="form-section">
                <h3 class="section-title">👤 Data Pribadi</h3>
                
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="fullName" class="form-label">Nama Lengkap *</label>
                    <input 
                      type="text" 
                      id="fullName" 
                      v-model="form.fullName" 
                      class="form-input"
                      required
                      placeholder="Masukkan nama lengkap"
                    />
                  </div>

                  <div class="form-group">
                    <label for="nim" class="form-label">NIM *</label>
                    <input 
                      type="text" 
                      id="nim" 
                      v-model="form.nim" 
                      class="form-input"
                      required
                      placeholder="Masukkan NIM"
                    />
                  </div>
                </div>

                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="email" class="form-label">Email *</label>
                    <input 
                      type="email" 
                      id="email" 
                      v-model="form.email" 
                      class="form-input"
                      required
                      placeholder="Masukkan email"
                    />
                  </div>

                  <div class="form-group">
                    <label for="username" class="form-label">Username *</label>
                    <input 
                      type="text" 
                      id="username" 
                      v-model="form.username" 
                      class="form-input"
                      required
                      placeholder="Masukkan username"
                    />
                  </div>
                </div>

                <div class="form-group">
                  <label for="password" class="form-label">Password *</label>
                  <input 
                    type="password" 
                    id="password" 
                    v-model="form.password" 
                    class="form-input"
                    required
                    placeholder="Masukkan password"
                  />
                </div>

                <div class="form-group">
                  <label for="photo" class="form-label">📸 Foto 3x4 *</label>
                  <div class="file-upload-container">
                    <input 
                      type="file" 
                      id="photo" 
                      @change="handlePhotoChange" 
                      class="form-file"
                      accept="image/*"
                      required
                    />
                    <div class="file-info">
                      <p class="text-sm">Format: JPG, PNG. Maksimal 2MB</p>
                      <p v-if="form.photo" class="text-sm text-success">
                        ✅ File dipilih: {{ form.photo.name }}
                      </p>
                    </div>
                  </div>
                </div>

                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="originAddress" class="form-label">Alamat Asal *</label>
                    <input 
                      type="text" 
                      id="originAddress" 
                      v-model="form.originAddress" 
                      class="form-input"
                      required
                      placeholder="Masukkan alamat asal"
                    />
                  </div>
                  <div class="form-group">
                    <label for="addressInSemarang" class="form-label">Alamat di Semarang *</label>
                    <input 
                      type="text" 
                      id="addressInSemarang" 
                      v-model="form.addressInSemarang" 
                      class="form-input"
                      required
                      placeholder="Masukkan alamat di Semarang"
                    />
                  </div>
                </div>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="birthPlace" class="form-label">Tempat Lahir *</label>
                    <input 
                      type="text" 
                      id="birthPlace" 
                      v-model="form.birthPlace" 
                      class="form-input"
                      required
                      placeholder="Masukkan tempat lahir"
                    />
                  </div>
                  <div class="form-group">
                    <label for="birthDate" class="form-label">Tanggal Lahir *</label>
                    <input 
                      type="date" 
                      id="birthDate" 
                      v-model="form.birthDate" 
                      class="form-input"
                      required
                    />
                  </div>
                </div>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="religion" class="form-label">Agama *</label>
                    <input 
                      type="text" 
                      id="religion" 
                      v-model="form.religion" 
                      class="form-input"
                      required
                      placeholder="Masukkan agama"
                    />
                  </div>
                  <div class="form-group">
                    <label for="gender" class="form-label">Jenis Kelamin *</label>
                    <select id="gender" v-model="form.gender" class="form-input" required>
                      <option value="">Pilih jenis kelamin</option>
                      <option value="Laki-laki">Laki-laki</option>
                      <option value="Perempuan">Perempuan</option>
                    </select>
                  </div>
                </div>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="bloodType" class="form-label">Golongan Darah *</label>
                    <input 
                      type="text" 
                      id="bloodType" 
                      v-model="form.bloodType" 
                      class="form-input"
                      required
                      placeholder="Masukkan golongan darah"
                    />
                  </div>
                  <div class="form-group">
                    <label for="previousSchool" class="form-label">Asal Sekolah *</label>
                    <input 
                      type="text" 
                      id="previousSchool" 
                      v-model="form.previousSchool" 
                      class="form-input"
                      required
                      placeholder="Masukkan asal sekolah"
                    />
                  </div>
                </div>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="highSchoolMajor" class="form-label">Jurusan SMA *</label>
                    <input 
                      type="text" 
                      id="highSchoolMajor" 
                      v-model="form.highSchoolMajor" 
                      class="form-input"
                      required
                      placeholder="Masukkan jurusan SMA"
                    />
                  </div>
                  <div class="form-group">
                    <label for="graduationYear" class="form-label">Tahun Lulus *</label>
                    <input 
                      type="number" 
                      id="graduationYear" 
                      v-model="form.graduationYear" 
                      class="form-input"
                      required
                      placeholder="Masukkan tahun lulus"
                    />
                  </div>
                </div>
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="selectedDepartment" class="form-label">Jurusan Pilihan *</label>
                    <input 
                      type="text" 
                      id="selectedDepartment" 
                      v-model="form.selectedDepartment" 
                      class="form-input"
                      required
                      placeholder="Masukkan jurusan pilihan"
                    />
                  </div>
                  <div class="form-group">
                    <label for="homePhone" class="form-label">Telepon Rumah *</label>
                    <input 
                      type="text" 
                      id="homePhone" 
                      v-model="form.homePhone" 
                      class="form-input"
                      required
                      placeholder="Masukkan telepon rumah"
                    />
                  </div>
                </div>
                <div class="form-group">
                  <label for="mobilePhone" class="form-label">No. HP Pribadi *</label>
                  <input 
                    type="text" 
                    id="mobilePhone" 
                    v-model="form.mobilePhone" 
                    class="form-input"
                    required
                    placeholder="Masukkan nomor HP pribadi"
                  />
                </div>
              </div>

              <!-- Data Orang Tua -->
              <div class="form-section">
                <h3 class="section-title">👨‍👩‍👧‍👦 Data Orang Tua</h3>
                
                <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div class="form-group">
                    <label for="fatherName" class="form-label">Nama Ayah *</label>
                    <input 
                      type="text" 
                      id="fatherName" 
                      v-model="form.parent.fatherName" 
                      class="form-input"
                      required
                      placeholder="Masukkan nama ayah"
                    />
                  </div>

                  <div class="form-group">
                    <label for="motherName" class="form-label">Nama Ibu *</label>
                    <input 
                      type="text" 
                      id="motherName" 
                      v-model="form.parent.motherName" 
                      class="form-input"
                      required
                      placeholder="Masukkan nama ibu"
                    />
                  </div>
                </div>

                <div class="form-group">
                  <label for="address" class="form-label">Alamat *</label>
                  <textarea 
                    id="address" 
                    v-model="form.parent.address" 
                    class="form-input form-textarea"
                    required
                    placeholder="Masukkan alamat lengkap"
                    rows="3"
                  ></textarea>
                </div>

                <div class="form-group">
                  <label for="phone" class="form-label">📞 No. HP *</label>
                  <input 
                    type="tel" 
                    id="phone" 
                    v-model="form.parent.phone" 
                    class="form-input"
                    required
                    placeholder="Masukkan nomor HP"
                  />
                </div>
              </div>

              <!-- Error Message -->
              <div v-if="error" class="error-message">
                {{ error }}
              </div>

              <!-- Submit Button -->
              <div class="form-actions">
                <button type="submit" :disabled="loading" class="btn btn-primary btn-large">
                  <span v-if="loading" class="spinner-small"></span>
                  {{ loading ? 'Mendaftar...' : '📝 Daftar Sekarang' }}
                </button>
              </div>
            </form>
          </div>

          <div class="card-footer">
            <p class="text-center">
              Sudah punya akun? 
              <router-link to="/login" class="text-primary">Login di sini</router-link>
            </p>
          </div>
        </div>
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
      error: '',
      form: {
        fullName: '',
        nim: '',
        email: '',
        username: '',
        password: '',
        photo: null,
        originAddress: '',
        addressInSemarang: '',
        birthPlace: '',
        birthDate: '',
        religion: '',
        gender: '',
        bloodType: '',
        previousSchool: '',
        highSchoolMajor: '',
        graduationYear: '',
        selectedDepartment: '',
        homePhone: '',
        mobilePhone: '',
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
          this.error = 'Ukuran file terlalu besar. Maksimal 2MB.';
          event.target.value = '';
          this.form.photo = null;
          return;
        }
        
        // Validasi tipe file
        if (!file.type.startsWith('image/')) {
          this.error = 'File harus berupa gambar (JPG, PNG, dll).';
          event.target.value = '';
          this.form.photo = null;
          return;
        }
        
        this.form.photo = file;
        this.error = '';
      }
    },
    
    async handleSubmit() {
      try {
        this.loading = true;
        this.error = '';
        
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
        
        formData.append('OriginAddress', this.form.originAddress);
        formData.append('AddressInSemarang', this.form.addressInSemarang);
        formData.append('BirthPlace', this.form.birthPlace);
        formData.append('BirthDate', this.form.birthDate);
        formData.append('Religion', this.form.religion);
        formData.append('Gender', this.form.gender);
        formData.append('BloodType', this.form.bloodType);
        formData.append('PreviousSchool', this.form.previousSchool);
        formData.append('HighSchoolMajor', this.form.highSchoolMajor);
        formData.append('GraduationYear', this.form.graduationYear);
        formData.append('SelectedDepartment', this.form.selectedDepartment);
        formData.append('HomePhone', this.form.homePhone);
        formData.append('MobilePhone', this.form.mobilePhone);
        
        await studentService.register(formData);
        
        // Success message
        alert('🎉 Pendaftaran berhasil! Silakan login setelah admin menyetujui pendaftaran Anda.');
        this.$router.push('/login');
        
      } catch (error) {
        console.error('Error registering:', error);
        this.error = error.response?.data?.message || 'Terjadi kesalahan saat mendaftar. Silakan coba lagi.';
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
}

.register-content {
  padding: 2rem 0;
}

.register-card {
  max-width: 800px;
  margin: 0 auto;
  background: white;
  border-radius: 1rem;
  box-shadow: 0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04);
  overflow: hidden;
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

.form-section {
  margin-bottom: 2rem;
}

.section-title {
  font-size: 1.25rem;
  color: #1f2937;
  margin-bottom: 1.5rem;
  padding-bottom: 0.5rem;
  border-bottom: 2px solid #e5e7eb;
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

.form-textarea {
  resize: vertical;
  min-height: 100px;
}

.form-file {
  width: 100%;
  padding: 0.75rem;
  border: 2px dashed #d1d5db;
  border-radius: 0.5rem;
  background: #f9fafb;
  cursor: pointer;
  transition: border-color 0.2s ease-in-out;
}

.form-file:hover {
  border-color: #667eea;
}

.form-file:focus {
  outline: none;
  border-color: #667eea;
  box-shadow: 0 0 0 3px rgba(102, 126, 234, 0.1);
}

.file-upload-container {
  position: relative;
}

.file-info {
  margin-top: 0.5rem;
}

.text-success {
  color: #10b981;
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

/* Grid utilities */
.grid {
  display: grid;
  gap: 1rem;
}

.grid-cols-1 { grid-template-columns: repeat(1, 1fr); }

@media (min-width: 768px) {
  .md\:grid-cols-2 { grid-template-columns: repeat(2, 1fr); }
}

/* Responsive Design */
@media (max-width: 768px) {
  .register-content {
    padding: 1rem 0;
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
  .card-header {
    padding: 1rem;
  }
  
  .card-body {
    padding: 1rem;
  }
  
  .card-footer {
    padding: 1rem;
  }
  
  .section-title {
    font-size: 1.125rem;
  }
}
</style>
