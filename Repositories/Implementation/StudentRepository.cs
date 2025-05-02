using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllAsync()
        {
            //get all students
            var students = _context.Students.ToList();
            return Task.FromResult(students);
        }

        public async Task<Student> GetAsync(Guid id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                throw new Exception($"Student with an ID of {id} not found");
            }

            return student;
        }

        public Task<Student> UpdateAsync(Guid id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
