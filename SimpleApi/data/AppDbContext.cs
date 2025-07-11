using Microsoft.EntityFrameworkCore;
using SimpleApi.Models; 

namespace SimpleApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
