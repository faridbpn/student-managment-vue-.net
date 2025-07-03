using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleApi.Models;

namespace SimpleApi.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        void AddParent(Parent parent);
        Task SaveChangesAsync();
        Task ApproveStudent(int id);
        Task RejectStudent(int id);
    }
}
