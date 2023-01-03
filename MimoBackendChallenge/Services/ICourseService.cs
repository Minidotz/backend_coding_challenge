using MimoBackendChallengeAPI.Models;
using MimoDomain;

namespace MimoBackendChallengeAPI.Services
{
    public interface ICourseService
    {
        Task<Course?> GetCourseById(int courseId);
        Task<bool> AddProgress(int courseId, int userId, LessonProgressAddDTO lesson);
        Task CheckChapterCompletion(Lesson lesson, DateTime startDateTime, DateTime endDateTime, int userId);
        Task CheckCourseCompletion(Chapter chapter, DateTime startDateTime, DateTime endDateTime, int userId);
        Task<Lesson?> GetLessonWithChapter(int lessonId);
    }
}