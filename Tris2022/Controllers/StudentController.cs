using Microsoft.AspNetCore.Mvc;
using Tris2022.Entity;
using Tris2022.Interfaces;
using Tris2022.Models;

namespace Tris2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(
            IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(AddStudentRequest student)
        {
            var newStudent = _studentRepository.AddStudent(student.StudentName ?? "NoName");
            return CreatedAtAction("GetStudentById", 
                new { newStudent.Id },
                newStudent);
        }

        [HttpDelete("{id}")]
        public ActionResult<Student> DeleteStudentById(int id)
        {
            return _studentRepository.DeleteStudentById(id);
        }
    }
}