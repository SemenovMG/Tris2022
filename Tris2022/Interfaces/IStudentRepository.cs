using Tris2022.Repositories;

namespace Tris2022.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<string> GetAllStudents();
        string GetStudentById(int id);
        AddStudentResult AddStudent(string studentName);
        string DeleteStudentById(int id);
    }
}
