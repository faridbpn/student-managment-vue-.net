using Microsoft.EntityFrameworkCore;
using SimpleApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace SimpleApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Pastikan database terbuat
            context.Database.EnsureCreated();

            // Cek apakah sudah ada user admin
            if (!context.Users.Any(u => u.Role == "Admin"))
            {
                // Buat user admin default
                var adminUser = new User
                {
                    Username = "admin",
                    PasswordHash = HashPassword("admin123"),
                    Role = "Admin"
                };

                context.Users.Add(adminUser);
                context.SaveChanges();
            }
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
} 