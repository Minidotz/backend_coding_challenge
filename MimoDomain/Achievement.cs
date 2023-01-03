namespace MimoDomain
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public AchievementType Type { get; set; } = AchievementType.Lesson;
        public int Units { get; set; }
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }

    public enum AchievementType
    {
        Course = 1,
        Chapter = 2,
        Lesson = 3
    }
}
