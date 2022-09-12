using Tris2022.Entity;
using Tris2022.Interfaces;
using Tris2022.Interfaces.Services;

namespace Tris2022.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(
            IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student AddStudent(string studentName)
        {
            if (_studentRepository.GetGroupSize() >= 5)
                throw new ArgumentException("Student group is full");
            var newStudent = _studentRepository.AddStudent(studentName);
            return newStudent;
        }

        public Student DeleteStudentById(int id)
        {
            return _studentRepository.DeleteStudentById(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }
    }
}
