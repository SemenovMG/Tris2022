namespace Tris2022.Models
{
    public class AddGroupResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MaxSize { get; set; }

        public List<GroupStudent> Students { get; set; }

        public class GroupStudent
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
