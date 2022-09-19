using Microsoft.AspNetCore.Mvc;
using Tris2022.Entity;
using Tris2022.Infrastructure.Data;
using Tris2022.Interfaces.Services;
using Tris2022.Models;

namespace Tris2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly DeansOfficeContext _db;
        public StudentController(
            IStudentService studentService,
            DeansOfficeContext db)
        {
            _studentService = studentService;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return _db.Products.ToList();
            //return _studentService.GetAllStudents();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            return _studentService.GetStudentById(id);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(AddStudentRequest student)
        {
            var newStudent = _studentService.AddStudent(student.StudentName ?? "NoName");
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