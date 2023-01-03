namespace MimoDomain
{
    public class CourseProgress
    {
        public int CourseProgressId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int? ChapterId { get; set; }
        public Chapter? Chapter { get; set; }
        public int? LessonId { get; set; }
        public Lesson? Lesson { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
