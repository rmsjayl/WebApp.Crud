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

        [HttpGet]
        [Route("api/Student/{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student = await _studentRepository.GetAsync(id);

            var response = new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Address = student.Address,
                CellPhoneNumber = student.CellPhoneNumber,
                University = student.University,
            };

            return Ok(response);
        }
        #endregion

        #region "POST"
        [HttpPost]
        [Route("/api/Student")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDto request)
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
        [HttpDelete]
        [Route("/api/Student/{id}")]
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
        [HttpPut]
        [Route("api/Student/{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentDto request)
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
