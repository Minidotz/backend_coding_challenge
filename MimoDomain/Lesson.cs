namespace MimoDomain
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; } = 1;
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}
