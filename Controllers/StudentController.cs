using Microsoft.AspNetCore.Mvc;
using WebApp.Crud.Models.Domain;
using WebApp.Crud.Models.DTOs;
using WebApp.Crud.Repositories.Interface;
using WebApp.Crud.Shared;


namespace WebApp.Crud.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly Helpers _helpers;

        public StudentController(IStudentRepository studentRepository, Helpers helpers)
        {
            _studentRepository = studentRepository;
            _helpers = helpers;
        }
        #region "GET"
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var students = await _studentRepository.GetAllAsync();
            var response = new List<StudentDto>();

            if (students == null || !students.Any())
            {
                return NotFound("No students found.");
            }

            foreach (var student in students)
            {
                var studentDto = new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName ?? string.Empty,
                    LastName = student.LastName ?? string.Empty,
                    Address = student.Address ?? string.Empty,
                    University = student.University ?? string.Empty,
                    CellPhoneNumber = student.CellPhoneNumber ?? string.Empty
                };
                response.Add(studentDto);
            }

            return View(response);
        }
        #endregion

        #region "POST"
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto request)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                University = request.University,
                CellPhoneNumber = request.CellPhoneNumber
            };

            student = await _studentRepository.CreateAsync(student);

            _helpers.PropNullChecker(student);

            var response = new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address = student.Address,
                University = student.University,
                CellPhoneNumber = student.CellPhoneNumber
            };

            return Ok(response);

        }
        #endregion

        #region "DELETE" 
        //FOR DELETE VIEW
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _studentRepository.GetAsync(id);
            return View(student);
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
        #endregion

        #region "UPDATE"

        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await _studentRepository.GetAsync(id);
            return View(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, UpdateStudentDto request)
        {
            var student = await _studentRepository.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            student.FirstName = request.FirstName ?? student.FirstName;
            student.LastName = request.LastName ?? student.LastName;
            student.Address = request.Address ?? student.Address;
            student.University = request.University ?? student.University;
            student.CellPhoneNumber = request.CellPhoneNumber ?? student.CellPhoneNumber;

            var updatedStudent = await _studentRepository.UpdateAsync(student);

            if (updatedStudent == null)
            {
                return NotFound();
            }

            return Ok(updatedStudent);
        }
        #endregion
    }
}
