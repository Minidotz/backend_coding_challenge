using MimoBackendChallengeAPI.Models;
using MimoBackendChallengeAPI.Services;
using MimoData.Repositories;
using MimoDomain;
using Moq;

namespace MimoBackendChallengeTests
{
    public class CourseServiceTests
    {
        [Fact]
        public async Task AddProgress_NewLessonProgressAdded_NewCourseProgressAdded()
        {
            //Arrange
            var newLessonDTO = new LessonProgressAddDTO()
            {
                LessonId = 2,
                StartDateTime = It.IsNotNull<DateTime>(),
                EndDateTime = It.IsNotNull<DateTime>()
            };
            var userWithNewLessonProgress = new User
            {
                UserId = 1,
                FirstName = It.IsAny<string>(),
                LastName = It.IsAny<string>()
            };
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetUserWithLessonProgress(1, newLessonDTO.LessonId))
                .ReturnsAsync(userWithNewLessonProgress);
            mimoTestRepo.Setup(m => m.GetLessonWithChapter(newLessonDTO.LessonId))
                .ReturnsAsync(new Lesson
                {
                    LessonId = 2,
                    Name = It.IsAny<string>(),
                    Sort = It.Is<int>(v => v > 0),
                    Chapter = new Chapter()
                    {
                        ChapterId = 1,
                        Name = It.IsAny<string>(),
                        Sort = It.Is<int>(v => v > 0),
                        CourseId = 1
                    },
                    ChapterId = 1
                });
            var courseService = new CourseService(mimoTestRepo.Object);

            //Act
            await courseService.AddProgress(1, 1, newLessonDTO);

            //Assert
            Assert.Equal(2, userWithNewLessonProgress.CourseProgress.Where(cp => cp.LessonId == 2 && cp.UserId == 1).Select(cp => cp.LessonId).First());
        }

        [Fact]
        public async Task AddProgress_UserRevisitsCompletedLesson_CourseProgressEndDateTimeIsUpdated()
        {
            //Arrange
            var currentDateTime = DateTime.Now;
            var revisitedLessonDTO = new LessonProgressAddDTO()
            {
                LessonId = 1,
                StartDateTime = It.IsNotNull<DateTime>(),
                EndDateTime = currentDateTime
            };
            var userWithExistingLessonProgress = new User
            {
                UserId = 1,
                FirstName = It.IsAny<string>(),
                LastName = It.IsAny<string>(),
                CourseProgress = new List<CourseProgress>()
                {
                    new CourseProgress
                    {
                        CourseId = 1,
                        ChapterId = 1,
                        LessonId = 1,
                        UserId = 1,
                        StartDateTime = It.IsNotNull<DateTime>(),
                        EndDateTime = new DateTime(2023, 1, 1)
                    }
                }
            };
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetUserWithLessonProgress(1, revisitedLessonDTO.LessonId))
                .ReturnsAsync(userWithExistingLessonProgress);
            mimoTestRepo.Setup(m => m.GetLessonWithChapter(revisitedLessonDTO.LessonId))
                .ReturnsAsync(new Lesson
                {
                    LessonId = 1,
                    Name = It.IsAny<string>(),
                    Sort = It.Is<int>(v => v > 0),
                    Chapter = new Chapter()
                    {
                        ChapterId = 1,
                        Name = It.IsAny<string>(),
                        Sort = It.Is<int>(v => v > 0),
                        CourseId = 1
                    },
                    ChapterId = 1
                });
            var courseService = new CourseService(mimoTestRepo.Object);

            //Act
            await courseService.AddProgress(1, 1, revisitedLessonDTO);

            //Assert
            Assert.Equal(revisitedLessonDTO.EndDateTime, userWithExistingLessonProgress.CourseProgress.Where(cp => cp.LessonId == 1 && cp.UserId == 1).Select(cp => cp.EndDateTime).First());
        }

        [Fact]
        public async Task CheckChapterCompletion_FirstLessonInChapterCompleted_ChapterCompletedProgressAdded()
        {
            //Arrange
            var lesson = new Lesson
            {
                LessonId = 1,
                Name = It.IsAny<string>(),
                Sort = 1,
                ChapterId = 1
            };
            var user = new User
            {
                UserId = 1,
                FirstName = It.IsAny<string>(),
                LastName = It.IsAny<string>()
            };
            var startDateTime = DateTime.Now;
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetChapterWithSortedLessons(1))
                .ReturnsAsync(new Chapter()
                {
                    ChapterId = 1,
                    Name = It.IsAny<string>(),
                    Sort = It.Is<int>(v => v > 0),
                    CourseId = 1,
                    Lessons = new List<Lesson> {
                        lesson,
                        new Lesson
                        {
                            LessonId = 2,
                            Name = It.IsAny<string>(),
                            Sort = 2,
                            ChapterId = 1
                        }
                    }
                });
            mimoTestRepo.Setup(m => m.GetChapterCompletedByUserRecord(1, 1))
                .ReturnsAsync((CourseProgress?) null);
            mimoTestRepo.Setup(m => m.GetUserById(1))
                .ReturnsAsync(user);
            var courseService = new CourseService(mimoTestRepo.Object);

            //Act
            await courseService.CheckChapterCompletion(lesson, startDateTime, It.IsNotNull<DateTime>(), 1);

            //Assert
            var chapterCompletedRecord = user.CourseProgress.Where(cp => cp.UserId == 1 && cp.CourseId == 1 && cp.ChapterId == 1 && cp.LessonId == null).SingleOrDefault();
            Assert.NotNull(chapterCompletedRecord);
            Assert.Null(chapterCompletedRecord.LessonId);
            Assert.Equal(1, chapterCompletedRecord.ChapterId);
            Assert.Equal(1, chapterCompletedRecord.CourseId);
            Assert.Equal(1, chapterCompletedRecord.UserId);
            Assert.Equal(startDateTime, chapterCompletedRecord.StartDateTime);
            Assert.Null(chapterCompletedRecord.EndDateTime);
        }

        [Fact]
        public async Task CheckChapterCompletion_LastLessonInChapterCompleted_ChapterCompletedProgressEndDateTimeUpdated()
        {
            //Arrange
            var lesson = new Lesson
            {
                LessonId = 2,
                Name = It.IsAny<string>(),
                Sort = 2,
                ChapterId = 1
            };
            var record = new CourseProgress
            {
                CourseId = 1,
                ChapterId = 1,
                LessonId = null,
                UserId = 1,
                StartDateTime = It.IsNotNull<DateTime>(),
                EndDateTime = null
            };
            var user = new User
            {
                UserId = 1,
                FirstName = It.IsAny<string>(),
                LastName = It.IsAny<string>(),
                CourseProgress = new List<CourseProgress>
                {
                    record
                }
            };
            var endDateTime = DateTime.Now;
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetChapterWithSortedLessons(1))
                .ReturnsAsync(new Chapter()
                {
                    ChapterId = 1,
                    Name = It.IsAny<string>(),
                    Sort = It.Is<int>(v => v > 0),
                    CourseId = 1,
                    Lessons = new List<Lesson> {
                        new Lesson
                        {
                            LessonId = 1,
                            Name = It.IsAny<string>(),
                            Sort = 1,
                            ChapterId = 1
                        },
                        lesson
                    }
                });
            mimoTestRepo.Setup(m => m.GetChapterCompletedByUserRecord(1, 1))
                .ReturnsAsync(record);
            mimoTestRepo.Setup(m => m.GetUserById(1))
                .ReturnsAsync(user);
            var courseService = new CourseService(mimoTestRepo.Object);

            //Act
            await courseService.CheckChapterCompletion(lesson, It.IsNotNull<DateTime>(), endDateTime, 1);

            //Assert
            var chapterCompletedRecord = user.CourseProgress.Where(cp => cp.UserId == 1 && cp.CourseId == 1 && cp.ChapterId == 1 && cp.LessonId == null).SingleOrDefault();
            Assert.NotNull(chapterCompletedRecord);
            Assert.Equal(endDateTime, chapterCompletedRecord.EndDateTime);
        }

        [Fact]
        public async Task CheckCourseCompletion_FirstChapterInCourseCompleted_CourseCompletedProgressAdded()
        {
            //Arrange
            var chapter = new Chapter
            {
                ChapterId = 1,
                Name = It.IsAny<string>(),
                Sort = 1,
                CourseId = 1
            };
            var user = new User
            {
                UserId = 1,
                FirstName = It.IsAny<string>(),
                LastName = It.IsAny<string>()
            };
            var startDateTime = DateTime.Now;
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetCourseWithSortedChapters(1))
                .ReturnsAsync(new Course()
                {
                    CourseId = 1,
                    Name = It.IsAny<string>(),
                    Chapters = new List<Chapter> {
                        chapter,
                        new Chapter
                        {
                            ChapterId = 2,
                            Name = It.IsAny<string>(),
                            Sort = 2,
                        }
                    }
                });
            mimoTestRepo.Setup(m => m.GetCourseCompletedByUserRecord(1, 1))
                .ReturnsAsync((CourseProgress?)null);
            mimoTestRepo.Setup(m => m.GetUserById(1))
                .ReturnsAsync(user);
            var courseService = new CourseService(mimoTestRepo.Object);

            //Act
            await courseService.CheckCourseCompletion(chapter, startDateTime, It.IsNotNull<DateTime>(), 1);

            //Assert
            var courseCompletedRecord = user.CourseProgress.Where(cp => cp.UserId == 1 && cp.CourseId == 1 && cp.ChapterId == null && cp.LessonId == null).SingleOrDefault();
            Assert.NotNull(courseCompletedRecord);
            Assert.Null(courseCompletedRecord.LessonId);
            Assert.Null(courseCompletedRecord.ChapterId);
            Assert.Equal(1, courseCompletedRecord.CourseId);
            Assert.Equal(1, courseCompletedRecord.UserId);
            Assert.Equal(startDateTime, courseCompletedRecord.StartDateTime);
            Assert.Null(courseCompletedRecord.EndDateTime);
        }

        [Fact]
        public async Task CheckCourseCompletion_LastChapterInCourseCompleted_CourseCompletedProgressEndDateTimeUpdated()
        {
            //Arrange
            var chapter = new Chapter
            {
                ChapterId = 2,
                Name = It.IsAny<string>(),
                Sort = 2,
                CourseId = 1
            };
            var record = new CourseProgress
            {
                CourseId = 1,
                ChapterId = null,
                LessonId = null,
                UserId = 1,
                StartDateTime = It.IsNotNull<DateTime>(),
                EndDateTime = null
            };
            var user = new User
            {
                UserId = 1,
                FirstName = It.IsAny<string>(),
                LastName = It.IsAny<string>(),
                CourseProgress = new List<CourseProgress>
                {
                    record
                }
            };
            var endDateTime = DateTime.Now;
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetCourseWithSortedChapters(1))
                .ReturnsAsync(new Course()
                {
                    CourseId = 1,
                    Name = It.IsAny<string>(),
                    Chapters = new List<Chapter> {
                        new Chapter
                        {
                            ChapterId = 1,
                            Name = It.IsAny<string>(),
                            Sort = 1,
                        },
                        chapter
                    }
                });
            mimoTestRepo.Setup(m => m.GetCourseCompletedByUserRecord(1, 1))
                .ReturnsAsync(record);
            mimoTestRepo.Setup(m => m.GetUserById(1))
                .ReturnsAsync(user);
            var courseService = new CourseService(mimoTestRepo.Object);

            //Act
            await courseService.CheckCourseCompletion(chapter, It.IsNotNull<DateTime>(), endDateTime, 1);

            //Assert
            var courseCompletedRecord = user.CourseProgress.Where(cp => cp.UserId == 1 && cp.CourseId == 1 && cp.ChapterId == null && cp.LessonId == null).SingleOrDefault();
            Assert.NotNull(courseCompletedRecord);
            Assert.Equal(endDateTime, courseCompletedRecord.EndDateTime);
        }
    }
}
