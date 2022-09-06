using Microsoft.AspNetCore.Mvc;

namespace Tris2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static readonly List<string> _students = new()
        {
            "Иванов", "Петров", "Сидоров"
        };

        public StudentController()
        {}

        [HttpGet]
        public IEnumerable<string> GetAllStudents()
        {
            return _students;
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetStudentById(int id)
        {
            if (id <0 || id >= _students.Count)
                return BadRequest("Wrong Id");
            return _students[id];
        }

        [HttpPost]
        public ActionResult<string> AddStudent(string studentName)
        {
            if (_students.Count >= 5)
                return BadRequest("Student group is full");
            var id = _students.Count;
            _students.Add(studentName);
            return CreatedAtAction("GetStudentById", new { id }, studentName);
            //return Ok(studentName);
            //return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteStudentById(int id)
        {
            if (id < 0 || id >= _students.Count)
                return BadRequest("Wrong Id");
            var studentToRemove = _students[id];
            _students.Remove(studentToRemove); ;
            return studentToRemove;
        }
    }
}