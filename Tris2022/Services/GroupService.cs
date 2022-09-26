using Tris2022.Entity;
using Tris2022.Interfaces;
using Tris2022.Interfaces.Services;
using Tris2022.Models;

namespace Tris2022.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(
            IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
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
    }
}
