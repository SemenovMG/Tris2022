using Microsoft.AspNetCore.Mvc;
using Tris2022.Repositories;

namespace Tris2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static readonly StudentFakeRepository _studentRepository = new ();
        public StudentController()
        {}

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
            //return Ok(studentName);
            //return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteStudentById(int id)
        {
            return _studentRepository.DeleteStudentById(id);
        }
    }
}