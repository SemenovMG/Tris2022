using Tris2022.Entity;
using Tris2022.Infrastructure.Data;
using Tris2022.Interfaces;

namespace Tris2022.Repositories
{
    public class GroupRepository: IGroupRepository
    {
        private readonly DeansOfficeContext _db;

        public GroupRepository(DeansOfficeContext db)
        {
            _db = db;
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return _db.Groups.ToList();
        }

        public Group GetGroupById(int id)
        {
            return _db.Groups.First(s => s.Id == id);
        }

        public Group AddGroup(Group newGroup)
        {
            _db.Groups.Add(newGroup);
            _db.SaveChanges();
            return newGroup;
        }

        public Group DeleteGroupById(int id)
        {
            var groupToDelete = _db.Groups.FirstOrDefault(s => s.Id == id);
            if (groupToDelete is null)
                throw new ArgumentException("Wrong Id");
            _db.Groups.Remove(groupToDelete);
            _db.SaveChanges();
            return groupToDelete;
        }
    }
}