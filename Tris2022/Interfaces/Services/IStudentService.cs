using Tris2022.Entity;
using Tris2022.Models;

namespace Tris2022.Interfaces.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        Student AddStudent(AddStudentRequest studentName);
        Student DeleteStudentById(int id);
    }
}
