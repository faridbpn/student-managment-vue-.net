# Frontend - Sistem Pendaftaran Mahasiswa Baru

Frontend Vue.js untuk sistem pendaftaran mahasiswa baru yang terhubung dengan backend ASP.NET Core.

## 🚀 Fitur

- **Pendaftaran Mahasiswa**: Form pendaftaran lengkap dengan upload foto
- **Login System**: Autentikasi dengan JWT token
- **Dashboard Mahasiswa**: Tampilan status pendaftaran dan data pribadi
- **Admin Panel**: Panel admin untuk approve/reject pendaftaran
- **Responsive Design**: Tampilan yang responsif untuk desktop dan mobile

## 🛠️ Teknologi

- **Vue.js 3**: Framework frontend
- **Vue Router**: Routing aplikasi
- **Axios**: HTTP client untuk API calls
- **Vite**: Build tool dan development server

## 📁 Struktur Folder

```
src/
├── components/          # Komponen Vue
├── views/              # Halaman aplikasi
│   ├── HomeView.vue    # Landing page
│   ├── RegisterView.vue # Form pendaftaran
│   ├── LoginView.vue   # Halaman login
│   ├── DashboardView.vue # Dashboard mahasiswa
│   ├── AdminView.vue   # Panel admin
│   └── AboutView.vue   # Halaman about
├── services/           # Service untuk API calls
│   ├── api.js         # Konfigurasi axios
│   ├── auth.js        # Service autentikasi
│   └── student.js     # Service mahasiswa
├── router/            # Konfigurasi routing
│   └── index.js       # Route definitions
├── assets/            # Assets (CSS, images)
├── App.vue           # Root component
└── main.js           # Entry point
```

## 🚀 Cara Menjalankan

### Prerequisites
- Node.js (versi 16 atau lebih baru)
- npm atau yarn

### Installation
```bash
# Install dependencies
npm install

# Jalankan development server
npm run dev

# Build untuk production
npm run build

# Preview build production
npm run preview
```

### Development Server
Setelah menjalankan `npm run dev`, aplikasi akan berjalan di:
- **URL**: http://localhost:5173
- **Network**: http://192.168.x.x:5173 (untuk akses dari device lain)

## 🔗 Koneksi ke Backend

Frontend terhubung ke backend ASP.NET Core melalui:
- **Base URL**: http://localhost:5000/api
- **CORS**: Backend harus mengizinkan origin frontend
- **Authentication**: JWT token untuk protected routes

## 📱 Halaman Aplikasi

### 1. Home (Landing Page)
- URL: `/`
- Deskripsi: Halaman utama dengan informasi sistem
- Fitur: Navigasi ke register dan login

### 2. Register
- URL: `/register`
- Deskripsi: Form pendaftaran mahasiswa baru
- Fitur:
  - Input data pribadi (nama, NIM, email, username, password)
  - Input data orang tua (ayah, ibu, alamat, HP)
  - Upload foto 3x4 (max 2MB)
  - Validasi form

### 3. Login
- URL: `/login`
- Deskripsi: Halaman login untuk mahasiswa dan admin
- Fitur:
  - Login dengan username dan password
  - Redirect otomatis berdasarkan role
  - Error handling

### 4. Dashboard Mahasiswa
- URL: `/dashboard`
- Deskripsi: Dashboard untuk mahasiswa yang sudah approved
- Fitur:
  - Tampilan profil dengan foto
  - Status pendaftaran (Pending/Approved/Rejected)
  - Data orang tua
  - Logout

### 5. Admin Panel
- URL: `/admin`
- Deskripsi: Panel admin untuk manage pendaftaran
- Fitur:
  - Daftar semua pendaftar
  - Statistik (total, pending, approved, rejected)
  - Approve/reject pendaftaran
  - Tampilan foto dan data lengkap

## 🔐 Authentication & Authorization

### JWT Token
- Token disimpan di localStorage
- Auto-include dalam setiap API request
- Auto-redirect ke login jika token expired

### Role-based Access
- **Mahasiswa**: Akses dashboard mahasiswa
- **Admin**: Akses admin panel
- **Navigation Guards**: Proteksi route berdasarkan role

## 📊 API Endpoints

Frontend menggunakan endpoint berikut:

### Auth
- `POST /api/auth/login` - Login user

### Student
- `POST /api/student` - Register mahasiswa baru
- `GET /api/student/dashboard` - Get dashboard mahasiswa

### Admin
- `GET /api/admin/students` - Get semua pendaftar
- `PUT /api/admin/students/{id}/approve` - Approve pendaftaran
- `PUT /api/admin/students/{id}/reject` - Reject pendaftaran

## 🎨 Styling

- **CSS Custom**: Styling custom tanpa framework CSS
- **Responsive**: Mobile-first design
- **Modern UI**: Gradient backgrounds, shadows, animations
- **Color Scheme**: Purple-blue gradient theme

## 🔧 Konfigurasi

### Environment Variables
Buat file `.env` untuk konfigurasi:
```env
VITE_API_BASE_URL=http://localhost:5000/api
```

### API Configuration
Edit `src/services/api.js` untuk mengubah base URL API.

## 🚨 Troubleshooting

### CORS Error
Pastikan backend mengizinkan origin frontend:
```csharp
app.UseCors(builder => 
    builder.WithOrigins("http://localhost:5173")
           .AllowAnyMethod()
           .AllowAnyHeader());
```

### API Connection Error
1. Pastikan backend berjalan di port 5000
2. Cek koneksi database
3. Periksa firewall/antivirus

### Build Error
1. Hapus `node_modules` dan `package-lock.json`
2. Jalankan `npm install` ulang
3. Cek versi Node.js (minimal v16)

## 📝 Notes

- Frontend menggunakan Vue 3 Composition API
- Semua API calls menggunakan Axios dengan interceptors
- File upload menggunakan FormData
- Responsive design untuk mobile dan desktop
- Error handling untuk semua API calls

## 🤝 Contributing

1. Fork repository
2. Buat feature branch
3. Commit changes
4. Push ke branch
5. Buat Pull Request

## 📄 License

MIT License
