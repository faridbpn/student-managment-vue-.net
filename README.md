# 🎓 Sistem Pendaftaran Mahasiswa Baru

Sistem web pendaftaran mahasiswa baru dengan teknologi modern dan responsive design.

## 🚀 Teknologi yang Digunakan

### Frontend
- **Vue.js 3** - Framework frontend modern
- **Vue Router** - Routing aplikasi
- **Axios** - HTTP client untuk API calls
- **Vite** - Build tool dan development server

### Backend
- **ASP.NET Core (.NET 8)** - Framework backend
- **Entity Framework Core** - ORM untuk database
- **JWT Authentication** - Sistem autentikasi
- **Repository Pattern** - Arsitektur clean code

### Database
- **SQL Server** - Database utama

## 📋 Fitur yang Tersedia

### 1. Halaman Registrasi Mahasiswa ✅
- Form pendaftaran lengkap dengan validasi
- Upload foto 3x4 (max 2MB)
- Data pribadi dan data orang tua
- Status default: "Pending"

### 2. Halaman Login (2 Role) ✅
- **Mahasiswa**: Login setelah di-approve admin
- **Admin**: Login untuk approval data
- JWT token authentication

### 3. Halaman Admin ✅
- List semua mahasiswa yang mendaftar
- Tombol Approve/Reject
- Tampilkan status (Pending, Approved, Rejected)
- Statistik pendaftaran

### 4. Dashboard Mahasiswa ✅
- Hanya untuk mahasiswa dengan status "Approved"
- Tampilan: "Welcome, [Nama Lengkap]"
- Foto yang diupload saat registrasi
- Status pendaftaran dan data orang tua

## 🛠️ Cara Menjalankan

### Prerequisites
- .NET 8 SDK
- SQL Server
- Node.js (v16+)
- npm atau yarn

### 1. Setup Database
```bash
# Masuk ke folder backend
cd SimpleApi

# Update database
dotnet ef database update
```

### 2. Jalankan Backend
```bash
# Masuk ke folder backend
cd SimpleApi

# Jalankan aplikasi
dotnet run --urls "http://localhost:5000"
```

Backend akan berjalan di: http://localhost:5000

### 3. Jalankan Frontend
```bash
# Masuk ke folder frontend
cd frontend

# Install dependencies (jika belum)
npm install

# Jalankan development server
npm run dev
```

Frontend akan berjalan di: http://localhost:5173

## 🔐 Demo Credentials

### Admin
- **Username**: `admin`
- **Password**: `admin123`
- **Role**: Admin
- **Akses**: Panel admin untuk approve/reject pendaftaran

### Mahasiswa
- Daftar dulu di halaman register
- Setelah di-approve admin, bisa login dan akses dashboard

## 📱 Responsive Design

Website sudah dioptimalkan untuk:
- **Desktop** (1024px+)
- **Tablet** (768px - 1023px)
- **Mobile** (320px - 767px)

### Fitur Responsive:
- Mobile-first design
- Touch-friendly buttons (min 44px)
- Responsive grid layout
- Mobile navigation menu
- Optimized forms untuk mobile

## 🔄 Alur Penggunaan

### 1. Pendaftaran Mahasiswa
1. Buka http://localhost:5173
2. Klik "Daftar Sekarang"
3. Isi form data pribadi dan orang tua
4. Upload foto 3x4
5. Submit form
6. Status: "Pending"

### 2. Login Admin
1. Buka http://localhost:5173/login
2. Login dengan credentials admin
3. Akses panel admin
4. Lihat list pendaftar
5. Approve/reject pendaftaran

### 3. Login Mahasiswa
1. Setelah di-approve admin
2. Login dengan username/password yang didaftarkan
3. Akses dashboard mahasiswa
4. Lihat status dan data pribadi

## 📊 API Endpoints

### Auth
- `POST /api/auth/login` - Login user

### Student
- `POST /api/student` - Register mahasiswa baru
- `GET /api/student/dashboard` - Get dashboard mahasiswa

### Admin
- `GET /api/admin/students` - Get semua pendaftar
- `PUT /api/admin/students/{id}/approve` - Approve pendaftaran
- `PUT /api/admin/students/{id}/reject` - Reject pendaftaran

## 🎨 UI/UX Features

### Modern Design
- Gradient backgrounds
- Card-based layout
- Smooth animations
- Loading states
- Error handling

### User Experience
- Intuitive navigation
- Clear form validation
- Success/error messages
- Responsive feedback
- Touch-friendly interface

### Accessibility
- Semantic HTML
- Keyboard navigation
- Screen reader friendly
- High contrast colors
- Proper ARIA labels

## 🚨 Troubleshooting

### Backend Issues
1. **Database Connection Error**
   - Cek connection string di `appsettings.json`
   - Pastikan SQL Server berjalan
   - Jalankan `dotnet ef database update`

2. **Port Already in Use**
   - Ganti port: `dotnet run --urls "http://localhost:5001"`
   - Update frontend API URL

3. **JWT Error**
   - Cek JWT configuration di `appsettings.json`
   - Restart backend

### Frontend Issues
1. **API Connection Error**
   - Cek backend berjalan di port 5000
   - Update API URL di `src/services/api.js`
   - Cek CORS configuration

2. **Build Error**
   - Hapus `node_modules` dan `package-lock.json`
   - Jalankan `npm install`
   - Cek Node.js version (min v16)

3. **CORS Error**
   - Pastikan backend CORS mengizinkan origin frontend
   - Restart backend dan frontend

## 📁 Struktur Project

```
manajemen mahasiswa vue/
├── frontend/                 # Vue.js frontend
│   ├── src/
│   │   ├── views/           # Halaman aplikasi
│   │   ├── services/        # API services
│   │   ├── router/          # Vue router
│   │   └── assets/          # CSS dan assets
│   └── package.json
└── SimpleApi/               # ASP.NET Core backend
    ├── Controllers/         # API controllers
    ├── Models/             # Database models
    ├── DTOs/               # Data transfer objects
    ├── Repositories/       # Repository pattern
    ├── Data/               # Database context
    └── Program.cs          # Application entry
```

## 🔧 Development

### Backend Development
```bash
cd SimpleApi
dotnet watch run
```

### Frontend Development
```bash
cd frontend
npm run dev
```

### Database Migrations
```bash
cd SimpleApi
dotnet ef migrations add MigrationName
dotnet ef database update
```

## 📝 Testing Checklist

### ✅ Backend Testing
- [ ] Database connection
- [ ] API endpoints response
- [ ] JWT authentication
- [ ] File upload functionality
- [ ] CORS configuration

### ✅ Frontend Testing
- [ ] Responsive design (desktop, tablet, mobile)
- [ ] Form validation
- [ ] API integration
- [ ] Navigation and routing
- [ ] Error handling

### ✅ User Flow Testing
- [ ] Mahasiswa registration
- [ ] Admin login dan approval
- [ ] Mahasiswa login setelah approval
- [ ] Dashboard functionality

## 🎯 Kriteria yang Dipenuhi

### ✅ Teknologi
- [x] Frontend: Vue.js
- [x] Backend: C# (.NET Core / ASP.NET Core)
- [x] Database: SQL Server
- [x] Arsitektur: Repository Pattern

### ✅ Fitur
- [x] Registrasi mahasiswa dengan form lengkap
- [x] Upload foto 3x4
- [x] Login 2 role (Admin & Mahasiswa)
- [x] Approval system oleh admin
- [x] Dashboard mahasiswa
- [x] Responsive design

### ✅ UI/UX
- [x] Modern dan responsive design
- [x] Mobile-friendly interface
- [x] Intuitive navigation
- [x] Clear visual feedback
- [x] Accessibility features

## 📞 Support

Jika ada masalah atau pertanyaan:
1. Cek troubleshooting section
2. Review error logs
3. Pastikan semua prerequisites terinstall
4. Restart backend dan frontend

---

**🎉 Sistem siap digunakan! Silakan test semua fitur sesuai alur yang telah dijelaskan.** 