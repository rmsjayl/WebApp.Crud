using Microsoft.AspNetCore.Mvc;
using WebApp.Crud.Data;
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
        public async Task<IActionResult> Get(StudentDto student)
        {
            await _studentRepository.GetAllAsync();
            return Ok(new { Message = "Get all students!" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _studentRepository.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}
