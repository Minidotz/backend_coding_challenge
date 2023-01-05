using Microsoft.EntityFrameworkCore;
using MimoData.DbContexts;
using MimoDomain;

namespace MimoData.Repositories
{
    public class MimoRepository : IMimoRepository
    {
        private readonly MimoContext mimoContext;

        public MimoRepository(MimoContext context)
        {
            mimoContext = context;
        }
        public async Task<User?> GetUserById(int userId)
        {
            return await mimoContext.Users.FindAsync(userId);
        }

        public async Task<User?> GetUserWithLessonProgress(int userId, int lessonId)
        {
            return await mimoContext.Users.Include(u => u.CourseProgress.Where(cp => cp.LessonId == lessonId)).FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User?> GetUserWithCoursesCompleted(int userId)
        {
            return await mimoContext.Users
                .AsNoTracking()
                .Include(u => u.CourseProgress.Where(cp => cp.UserId == userId && cp.ChapterId == null && cp.LessonId == null && cp.EndDateTime != null))
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserWithCourseCompleted(int userId, int? courseId)
        {
            return await mimoContext.Users
                .AsNoTracking()
                .Include(u => u.CourseProgress.Where(cp => cp.UserId == userId && cp.CourseId == courseId && cp.ChapterId == null && cp.LessonId == null && cp.EndDateTime != null))
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserWithChaptersCompleted(int userId)
        {
            return await mimoContext.Users
                .AsNoTracking()
                .Include(u => u.CourseProgress.Where(cp => cp.UserId == userId && cp.ChapterId != null && cp.LessonId == null && cp.EndDateTime != null))
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetUserWithLessonsCompleted(int userId)
        {
            return await mimoContext.Users
                .AsNoTracking()
                .Include(u => u.CourseProgress.Where(cp => cp.UserId == userId && cp.LessonId != null && cp.EndDateTime != null))
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }
        public async Task<Course?> GetCourseById(int courseId)
        {
            return await mimoContext.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.CourseId == courseId);
        }

        public async Task<Course?> GetCourseWithSortedChapters(int courseId)
        {
            return await mimoContext.Courses
                .AsNoTracking()
                .Include(c => c.Chapters.OrderBy(c => c.Sort))
                .Where(c => c.CourseId == courseId)
                .FirstOrDefaultAsync();
        }

        public async Task<Chapter?> GetChapterWithSortedLessons(int chapterId)
        {
            return await mimoContext.Chapters
                .AsNoTracking()
                .Include(c => c.Lessons.OrderBy(l => l.Sort))
                .Where(c => c.ChapterId == chapterId)
                .FirstOrDefaultAsync();
        }

        public async Task<Lesson?> GetLessonWithChapter(int lessonId)
        {
            return await mimoContext.Lessons
                .AsNoTracking()
                .Include(l => l.Chapter)
                .FirstOrDefaultAsync(l => l.LessonId == lessonId);
        }
        public async Task<CourseProgress?> GetChapterCompletedByUserRecord(int userId, int chapterId)
        {
            return await mimoContext.Users
                .Where(u => u.UserId == userId)
                .Select(u => u.CourseProgress.Where(cp => cp.UserId == userId && cp.ChapterId == chapterId && cp.LessonId == null).First())
                .FirstOrDefaultAsync();
        }

        public async Task<CourseProgress?> GetCourseCompletedByUserRecord(int userId, int courseId)
        {
            return await mimoContext.Users
                .Where(u => u.UserId == userId)
                .Select(u => u.CourseProgress.Where(cp => cp.UserId == userId && cp.CourseId == courseId && cp.ChapterId == null && cp.LessonId == null).First())
                .FirstOrDefaultAsync();
        }

        public async Task<List<Achievement>> GetAchievements()
        {
            return await mimoContext.Achievements.AsNoTracking().ToListAsync();
        }

        public async Task<Achievement?> GetAchievementById(int achievementId)
        {
            return await mimoContext.Achievements.AsNoTracking().FirstOrDefaultAsync(a => a.AchievementId == achievementId);
        }

        public async Task<int> SaveChanges()
        {
            return await mimoContext.SaveChangesAsync();
        }
    }
}
