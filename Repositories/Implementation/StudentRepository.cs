using WebApp.Crud.Data;
using WebApp.Crud.Models.Domain;
using WebApp.Crud.Repositories.Interface;

namespace WebApp.Crud.Repositories.Implementation
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Student> CreateAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllAsync()
        {
            //get all students
            var students = _context.Students.ToList();
            return Task.FromResult(students);
        }

        public Task<Student> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateAsync(int id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
