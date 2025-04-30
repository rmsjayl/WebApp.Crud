using Microsoft.AspNetCore.Mvc;

namespace WebApp.Crud.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Name = "John Doe", Age = 25 });
        }

        [HttpPost]
        public IActionResult Post([FromBody] string name)
        {
            return Ok(new { Message = $"Student {name} created successfully!" });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string name)
        {
            return Ok(new { Message = $"Student {id} updated to {name}!" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(new { Message = $"Student {id} deleted successfully!" });
        }
    }
}
