using Microsoft.AspNetCore.Mvc;
using Tris2022.Entity;
using Tris2022.Interfaces.Services;
using Tris2022.Models;

namespace Tris2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(
            IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return _studentService.GetAllStudents();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            return _studentService.GetStudentById(id);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(AddStudentRequest req)
        {
            var newStudent = _studentService.AddStudent(req);
            return CreatedAtAction("GetStudentById", 
                new { newStudent.Id },
                newStudent);
        }

        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudentById(int id)
        {
            return _studentService.DeleteStudentById(id);
        }
    }
}