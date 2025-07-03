using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleApi.Data;
using SimpleApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SimpleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;
        private readonly ILogger<AccountController> _logger;

        public AccountController(AppDbContext context, IConfiguration config, ILogger<AccountController> logger)
        {
            _context = context;
            _config = config;
            _logger = logger;
        }

        // ✅ Buat Admin Default jika belum ada
        [HttpGet("check-admin")]
        public async Task<IActionResult> CheckAdmin()
        {
            var adminExists = await _context.Users.AnyAsync(u => u.Role == "Admin");
            if (adminExists)
            {
                return Ok(new { message = "Admin already exists." });
            }

            var admin = new User
            {
                Username = "admin",
                PasswordHash = HashPassword("admin123"),
                Role = "Admin"
            };

            _context.Users.Add(admin);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Admin created.",
                admin = new { admin.Username, Password = "admin123" }
            });
        }

        // ✅ Login - Generate JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username) || string.IsNullOrWhiteSpace(dto.Password))
                return BadRequest(new { message = "Username dan Password wajib diisi." });

            var hashedPassword = HashPassword(dto.Password);

            var user = await _context.Users
                .Include(u => u.Student)
                .FirstOrDefaultAsync(u => u.Username == dto.Username && u.PasswordHash == hashedPassword);

            if (user == null)
                return Unauthorized(new { message = "Username atau password salah." });

            if (user.Role == "Student" && (user.Student?.Status != "Approved"))
                return Unauthorized(new { message = "Akun Anda belum disetujui oleh admin." });

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                token,
                user = new
                {
                    user.Id,
                    user.Username,
                    user.Role
                }
            });
        }

        // 🔐 Hash Password dengan SHA256
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        // 🔐 Generate JWT Token
        private string GenerateJwtToken(User user)
        {
            var key = _config["Jwt:Key"];
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // ✅ DTO untuk login
    public class LoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
