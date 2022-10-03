using Tris2022.Entity;

namespace Tris2022.Interfaces
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAllGroups();
        Group GetGroupById(int id);
        Group AddGroup(Group GroupName);
        Group DeleteGroupById(int id);
        Group GetGroupWithStudents(int id);
        Group AddStudent(Group group, Student student);
    }
}
