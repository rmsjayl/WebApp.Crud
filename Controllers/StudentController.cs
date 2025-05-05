using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using WebApp.Crud.Data;
using WebApp.Crud.Models.Domain;
using WebApp.Crud.Models.DTOs;
using WebApp.Crud.Repositories.Interface;


namespace WebApp.Crud.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(StudentDto request)
        {

            var students = await _studentRepository.GetAllAsync();
            var response = new List<StudentDto>();

            foreach (var student in students)
            {
                var studentDto = new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Address = student.Address,
                    University = student.University,
                    CellPhoneNumber = student.CellPhoneNumber
                };
                response.Add(studentDto);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var student = await _studentRepository.GetAsync(id);
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto request)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                University = request.University,
            };

            var createdStudent = await _studentRepository.CreateAsync(student);

            var response = new CreateStudentDto
            {
                FirstName = createdStudent.FirstName,
                LastName = createdStudent.LastName,
                Address = createdStudent.Address,
                University = createdStudent.University,
                CellPhoneNumber = createdStudent.CellPhoneNumber
            };

            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _studentRepository.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var result = await _studentRepository.DeleteAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, UpdateStudentDto request)
        {
            var student = new Student
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                University = request.University,
                CellPhoneNumber = request.CellPhoneNumber
            };

            var updatedStudent = await _studentRepository.UpdateAsync(student);

            if (updatedStudent == null)
            {
                return NotFound();
            }

            return Ok(updatedStudent);
        }
    }


}
