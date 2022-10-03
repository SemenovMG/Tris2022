using Tris2022.Entity;
using Tris2022.Models;

namespace Tris2022.Interfaces.Services
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAllGroups();
        Group GetGroupById(int id);
        Group AddGroup(AddGroupRequest GroupName);
        Group DeleteGroupById(int id);
        AddGroupResponse AddStudent(int groupId, AddStudentToGroupRequest request);
    }
}
