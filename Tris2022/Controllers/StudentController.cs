using Microsoft.AspNetCore.Mvc;
using Tris2022.Interfaces;

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
        public IEnumerable<string> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        [HttpPost]
        public ActionResult<string> AddStudent(string studentName)
        {
            var newStudent = _studentRepository.AddStudent(studentName);
            return CreatedAtAction("GetStudentById", 
                new { newStudent.Id }, 
                newStudent.Student);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteStudentById(int id)
        {
            return _studentRepository.DeleteStudentById(id);
        }
    }
}