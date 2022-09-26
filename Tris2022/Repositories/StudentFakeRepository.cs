using Tris2022.Entity;
using Tris2022.Interfaces;

namespace Tris2022.Repositories
{
    public class StudentFakeRepository: IStudentRepository
    {
        private static readonly List<Student> _students = new()
        {
            new Student
            {
                Id = 1,
                Name = "Иванов",
            },
            new Student
            {
                Id = 2,
                Name = "Петров",
            },
            new Student
            {
                Id = 3,
                Name = "Сидоров",
            },
        };

        private static int nextId = 4;

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student is null)
                throw new ArgumentException("Wrong Id");
            return student;
        }

        public Student AddStudent(Student studentData)
        {
            var newStudent = new Student
            {
                Name = studentData.Name,
                Id = nextId++,
            };
            _students.Add(newStudent);
            return newStudent;
        }

        public Student DeleteStudentById(int id)
        {
            var studentToDelete = _students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete is null)
                throw new ArgumentException("Wrong Id");
            if (!_students.Remove(studentToDelete))
            {
                throw new Exception("student cant be removed");
            }
            return studentToDelete;
        }

        public int GetGroupSize()
        {
            return _students.Count;
        }
    }
}