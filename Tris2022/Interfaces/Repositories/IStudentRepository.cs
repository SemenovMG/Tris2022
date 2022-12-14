using Tris2022.Entity;

namespace Tris2022.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student AddStudent(Student studentName);
        Student DeleteStudentById(int id);
    }
}
