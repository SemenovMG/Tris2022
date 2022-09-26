using Tris2022.Entity;
using Tris2022.Infrastructure.Data;
using Tris2022.Interfaces;

namespace Tris2022.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly DeansOfficeContext _db;

        public StudentRepository(DeansOfficeContext db)
        {
            _db = db;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _db.Students.First(s => s.Id == id);
        }

        public Student AddStudent(Student newStudent)
        {
            _db.Students.Add(newStudent);
            _db.SaveChanges();
            return newStudent;
        }

        public Student DeleteStudentById(int id)
        {
            var studentToDelete = _db.Students.FirstOrDefault(s => s.Id == id);
            if (studentToDelete is null)
                throw new ArgumentException("Wrong Id");
            _db.Students.Remove(studentToDelete);
            _db.SaveChanges();
            return studentToDelete;
        }
    }
}