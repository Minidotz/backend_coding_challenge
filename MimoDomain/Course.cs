namespace MimoDomain
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
    }
}
