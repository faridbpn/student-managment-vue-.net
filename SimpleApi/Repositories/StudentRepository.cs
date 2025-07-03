using SimpleApi.Data;
using SimpleApi.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleApi.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.Include(p => p.Parent).ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.Include(p => p.Parent).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public void AddParent(Parent parent)
        {
            _context.Parents.Add(parent);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task ApproveStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                student.Status = "Approved";
                await _context.SaveChangesAsync();
            }
        }

        public async Task RejectStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                student.Status = "Rejected";
                await _context.SaveChangesAsync();
            }
        }
    }
}
