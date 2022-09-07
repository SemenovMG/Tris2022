namespace Tris2022.Repositories
{
    public class StudentFakeRepository
    {
        private static readonly List<string> _students = new()
        {
            "Иванов",
            "Петров",
            "Сидоров"
        };

        public IEnumerable<string> GetAllStudents()
        {
            return _students;
        }

        public string GetStudentById(int id)
        {
            if (id < 0 || id >= _students.Count)
                throw new ArgumentException("Wrong Id");
            return _students[id];
        }

        public AddStudentResult AddStudent(string studentName)
        {
            if (_students.Count >= 5)
                throw new ArgumentException("Student group is full");
            var id = _students.Count;
            _students.Add(studentName);
            return new AddStudentResult
            {
                Id = id,
                Student = studentName
            };
        }

        public string DeleteStudentById(int id)
        {
            if (id < 0 || id >= _students.Count)
                throw new ArgumentException("Wrong Id");
            var studentToRemove = _students[id];
            _students.Remove(studentToRemove); ;
            return studentToRemove;
        }
    }

    public class AddStudentResult {
        public string? Student { get; set; }
        public int Id { get; set; }
    }
}
