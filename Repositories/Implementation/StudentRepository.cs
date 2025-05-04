using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApp.Crud.Data;
using WebApp.Crud.Models.Domain;
using WebApp.Crud.Models.DTOs;
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

        public async Task<Student> CreateAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteAsync(Guid id)
        {

            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                throw new Exception($"Student with an ID of {id} not found");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            //get all students
            var students = await _context.Students.ToListAsync();
            return students;
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
