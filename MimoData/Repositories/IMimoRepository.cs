using MimoDomain;

namespace MimoData.Repositories
{
    public interface IMimoRepository
    {
        Task<Achievement?> GetAchievementById(int achievementId);
        Task<List<Achievement>> GetAchievements();
        Task<CourseProgress?> GetChapterCompletedByUserRecord(int userId, int chapterId);
        Task<Chapter?> GetChapterWithSortedLessons(int chapterId);
        Task<Course?> GetCourseById(int courseId);
        Task<CourseProgress?> GetCourseCompletedByUserRecord(int userId, int courseId);
        Task<Course?> GetCourseWithSortedChapters(int courseId);
        Task<Lesson?> GetLessonWithChapter(int lessonId);
        Task<User?> GetUserById(int userId);
        Task<User?> GetUserWithChaptersCompleted(int userId);
        Task<User?> GetUserWithCourseCompleted(int userId, int? courseId);
        Task<User?> GetUserWithCoursesCompleted(int userId);
        Task<User?> GetUserWithLessonProgress(int userId, int lessonId);
        Task<User?> GetUserWithLessonsCompleted(int userId);
        Task<int> SaveChanges();
    }
}