namespace MimoDomain
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; } = 1;
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
