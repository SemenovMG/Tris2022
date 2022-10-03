namespace Tris2022.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "NoName";

        int? GroupId { get; set; }

        public Group? Group { get; set; }
    }
}