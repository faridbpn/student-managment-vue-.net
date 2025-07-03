using Microsoft.AspNetCore.Mvc;
using SimpleApi.Repositories;
using SimpleApi.Models;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IWebHostEnvironment _env;

        public StudentController(IStudentRepository repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterStudentDto dto)
        {
            // 1. Simpan Foto
            string uploads = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploads);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(dto.Photo.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Photo.CopyToAsync(stream);
            }

            // 2. Buat Student & Parent Object
            var student = new Student
            {
                FullName = dto.FullName,
                OriginAddress = dto.OriginAddress,
                AddressInSemarang = dto.AddressInSemarang,
                BirthPlace = dto.BirthPlace,
                BirthDate = dto.BirthDate,
                Religion = dto.Religion,
                Gender = dto.Gender,
                BloodType = dto.BloodType,
                PreviousSchool = dto.PreviousSchool,
                HighSchoolMajor = dto.HighSchoolMajor,
                GraduationYear = dto.GraduationYear,
                SelectedDepartment = dto.SelectedDepartment,
                HomePhone = dto.HomePhone,
                MobilePhone = dto.MobilePhone,
                PhotoPath = $"/uploads/{fileName}",
                Status = "Pending",
                Parent = new Parent
                {
                    FatherName = dto.FatherName,
                    MotherName = dto.MotherName,
                    Address = dto.ParentAddress,
                    Phone = dto.ParentPhone
                }
            };

            // 3. Simpan ke Database
            await _repository.AddAsync(student);
            return Ok(new { message = "Registration submitted." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpPut("{id}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            await _repository.ApproveStudent(id);
            return Ok();
        }

        [HttpPut("{id}/reject")]
        public async Task<IActionResult> Reject(int id)
        {
            await _repository.RejectStudent(id);
            return Ok();
        }
    }
}
