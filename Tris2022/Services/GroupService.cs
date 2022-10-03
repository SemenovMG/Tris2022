using Tris2022.Entity;
using Tris2022.Interfaces;
using Tris2022.Interfaces.Services;
using Tris2022.Models;

namespace Tris2022.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;

        public GroupService(
            IGroupRepository groupRepository,
            IStudentRepository studentRepository)
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
        }

        public Group AddGroup(AddGroupRequest request)
        {
            var newGroup = new Group()
            {
                Title = request.Title,
                MaxSize = request.MaxSize,
            };
            return _groupRepository.AddGroup(newGroup);
        }

        public Group DeleteGroupById(int id)
        {
            return _groupRepository.DeleteGroupById(id);
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return _groupRepository.GetAllGroups();
        }

        public Group GetGroupById(int id)
        {
            return _groupRepository.GetGroupById(id);
        }

        public AddGroupResponse AddStudent(int groupId, AddStudentToGroupRequest request)
        {

            var group = _groupRepository
                .GetGroupWithStudents(groupId);
            if (group.Students.Count >= group.MaxSize)
                throw new Exception("Group is full");
            var student = _studentRepository.GetStudentById(request.StudentId);
            group = _groupRepository.AddStudent(group, student);
            AddGroupResponse response = new()
            {
                Id = group.Id,
                MaxSize = group.MaxSize,
                Title = group.Title,
                Students = group.Students.Select(s => new AddGroupResponse.GroupStudent()
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList()
            };
            return response;
        }
    }
}
