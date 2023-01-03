using MimoBackendChallengeAPI.Models;
using MimoData.Repositories;
using MimoDomain;

namespace MimoBackendChallengeAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMimoRepository mimoRepository;

        public CourseService(IMimoRepository repository)
        {
            this.mimoRepository = repository;
        }

        public async Task<Course?> GetCourseById(int courseId)
        {
            return await mimoRepository.GetCourseById(courseId);
        }

        public async Task<Lesson?> GetLessonWithChapter(int lessonId)
        {
            return await mimoRepository.GetLessonWithChapter(lessonId);
        }

        public async Task<bool> AddProgress(int courseId, int userId, LessonProgressAddDTO lessonDTO)
        {
            var user = await mimoRepository.GetUserWithLessonProgress(userId, lessonDTO.LessonId);
            var lesson = await GetLessonWithChapter(lessonDTO.LessonId);
            if (user != null && lesson != null)
            {
                if (user.CourseProgress.Any())
                {
                    var record = user.CourseProgress.First();
                    record.StartDateTime = lessonDTO.StartDateTime;
                    record.EndDateTime = lessonDTO.EndDateTime;
                }
                else
                {
                    user.CourseProgress.Add(
                        new CourseProgress
                        {
                            UserId = userId,
                            LessonId = lessonDTO.LessonId,
                            CourseId = courseId,
                            ChapterId = lesson.ChapterId,
                            StartDateTime = lessonDTO.StartDateTime,
                            EndDateTime = lessonDTO.EndDateTime
                        });
                }
                var changes = await mimoRepository.SaveChanges();
                if (changes > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task CheckChapterCompletion(Lesson lesson, DateTime startDateTime, DateTime endDateTime, int userId)
        {
            var chapter = await mimoRepository.GetChapterWithSortedLessons(lesson.ChapterId);
            var lessonsInChapter = chapter?.Lessons;
            var firstLessonInChapter = lessonsInChapter?.First();
            var lastLessonInChapter = lessonsInChapter?.Last();
            if (firstLessonInChapter?.LessonId == lesson.LessonId || lastLessonInChapter?.LessonId == lesson.LessonId)
            {
                var chapterCompletedRecord = await mimoRepository.GetChapterCompletedByUserRecord(userId, lesson.ChapterId);

                //Case when there's only one lesson in the chapter
                if (firstLessonInChapter?.LessonId == lastLessonInChapter?.LessonId)
                {
                    await UpdateCourseProgress(userId, startDateTime, endDateTime, chapterCompletedRecord, chapter.CourseId, lesson.ChapterId);
                }
                else
                {
                    if (firstLessonInChapter?.LessonId == lesson.LessonId)
                    {
                        //Only update progress when record is not found in case the user is revisiting the first lesson of the chapter
                        if (chapterCompletedRecord == null)
                        {
                            await UpdateCourseProgress(userId, startDateTime, null, chapterCompletedRecord, chapter.CourseId, lesson.ChapterId);
                        }
                    }
                    if (lastLessonInChapter?.LessonId == lesson.LessonId)
                    {
                        //Both checks are needed in case the user is revisiting the last lesson of the chapter
                        if (chapterCompletedRecord != null && chapterCompletedRecord.EndDateTime == null)
                        {
                            await UpdateCourseProgress(userId, startDateTime, endDateTime, chapterCompletedRecord, chapter.CourseId, lesson.ChapterId);
                        }
                    }
                }
            }
        }

        private async Task UpdateCourseProgress(int userId, DateTime startDateTime, DateTime? endDateTime, CourseProgress? completedRecord, int courseId, int? chapterId = null, int? lessonId = null)
        {
            var user = await mimoRepository.GetUserById(userId);
            if (user != null)
            {
                if (completedRecord == null)
                {
                    user.CourseProgress.Add(
                        new CourseProgress
                        {
                            UserId = userId,
                            LessonId = lessonId,
                            CourseId = courseId,
                            ChapterId = chapterId,
                            StartDateTime = startDateTime,
                            EndDateTime = endDateTime
                        });
                }
                else
                {
                    completedRecord.EndDateTime = endDateTime;
                }
                await mimoRepository.SaveChanges();
            }
        }

        public async Task CheckCourseCompletion(Chapter chapter, DateTime startDateTime, DateTime endDateTime, int userId)
        {
            var course = await mimoRepository.GetCourseWithSortedChapters(chapter.CourseId);
            var chaptersInCourse = course?.Chapters;
            var firstChapterInCourse = chaptersInCourse?.First();
            var lastChapterInCourse = chaptersInCourse?.Last();
            if (firstChapterInCourse?.ChapterId == chapter.ChapterId || lastChapterInCourse?.ChapterId == chapter.ChapterId)
            {
                var courseCompletedRecord = await mimoRepository.GetCourseCompletedByUserRecord(userId, chapter.CourseId);
                //Case when there's only one chapter in the course
                if (firstChapterInCourse?.ChapterId == lastChapterInCourse?.ChapterId)
                {
                    await UpdateCourseProgress(userId, startDateTime, endDateTime, courseCompletedRecord, course.CourseId);
                }
                else
                {
                    if (firstChapterInCourse?.ChapterId == chapter.ChapterId)
                    {
                        //Only update progress when record is not found in case the user is revisiting the first chapter of the course
                        if (courseCompletedRecord == null)
                        {
                            await UpdateCourseProgress(userId, startDateTime, null, courseCompletedRecord, course.CourseId);
                        }
                    }
                    if (lastChapterInCourse?.ChapterId == chapter.ChapterId)
                    {
                        //Both checks are needed in case the user is revisiting the last chapter of the course
                        if (courseCompletedRecord != null && courseCompletedRecord.EndDateTime == null)
                        {
                            await UpdateCourseProgress(userId, startDateTime, endDateTime, courseCompletedRecord, course.CourseId);
                        }
                    }
                }
            }
        }
    }
}
