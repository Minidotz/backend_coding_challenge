using MimoBackendChallengeAPI.Models;
using MimoBackendChallengeAPI.Services;
using MimoData.Repositories;
using MimoDomain;
using Moq;
using System.Xml.Linq;

namespace MimoBackendChallengeTests
{
    public class AchievementServiceTests
    {
        [Fact]
        public async Task GetUserAchievements_Fetch5LessonsCompletedAnd10LessonsCompletedAchievementsAndUserCompletedOneLesson_ProgressEqualsOneForBothAchievements()
        {
            //Arrange
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetAchievements())
                .ReturnsAsync(new List<Achievement>()
                {
                    new Achievement
                    {
                        AchievementId = 1,
                        Name= "5 Lessons Completed",
                        Units = 5,
                        CourseId = null
                    },
                    new Achievement
                    {
                        AchievementId = 2,
                        Name= "10 Lessons Completed",
                        Units = 10,
                        CourseId = null
                    },
                });
            mimoTestRepo.Setup(m => m.GetUserWithLessonsCompleted(1))
                .ReturnsAsync(new User
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
                            EndDateTime = It.IsNotNull<DateTime>(),
                        }
                    }
                });
            var achievementService = new AchievementService(mimoTestRepo.Object);

            //Act
            var achievements = await achievementService.GetUserAchievements(1);

            //Assert
            Assert.Equal(1, achievements.First(a => a.AchievementId == 1).Progress);
            Assert.Equal(1, achievements.First(a => a.AchievementId == 2).Progress);
        }

        [Fact]
        public async Task GetUserAchievement_OneChapterCompletedAchievementAndUserCompletedOneChapter_ReturnsUserAchievementDTOWithIsCompletedEqualToTrue()
        {
            //Arrange
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetAchievementById(1))
                .ReturnsAsync(new Achievement
                {
                    AchievementId = 1,
                    Name= "1 Chapter Completed",
                    Type = AchievementType.Chapter,
                    Units = 1,
                    CourseId = null
                });
            mimoTestRepo.Setup(m => m.GetUserWithChaptersCompleted(1))
                .ReturnsAsync(new User
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
                            LessonId = null,
                            UserId = 1,
                            StartDateTime = It.IsNotNull<DateTime>(),
                            EndDateTime = It.IsNotNull<DateTime>(),
                        }
                    }
                });
            var achievementService = new AchievementService(mimoTestRepo.Object);

            //Act
            var achievement = await achievementService.GetUserAchievement(1, 1);

            //Assert
            Assert.IsType<UserAchievementDTO>(achievement);
            Assert.True(achievement.IsCompleted);
        }

        [Fact]
        public async Task GetUserAchievement_FiveChaptersCompletedAchievementAndUserCompletedOneChapter_ReturnsUserAchievementDTOWithProgressEqualToOne()
        {
            //Arrange
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetAchievementById(1))
                .ReturnsAsync(new Achievement
                {
                    AchievementId = 1,
                    Name = "5 Chapters Completed",
                    Type = AchievementType.Chapter,
                    Units = 1,
                    CourseId = null
                });
            mimoTestRepo.Setup(m => m.GetUserWithChaptersCompleted(1))
                .ReturnsAsync(new User
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
                            LessonId = null,
                            UserId = 1,
                            StartDateTime = It.IsNotNull<DateTime>(),
                            EndDateTime = It.IsNotNull<DateTime>(),
                        }
                    }
                });
            var achievementService = new AchievementService(mimoTestRepo.Object);

            //Act
            var achievement = await achievementService.GetUserAchievement(1, 1);

            //Assert
            Assert.IsType<UserAchievementDTO>(achievement);
            Assert.Equal(1, achievement.Progress);
        }

        [Fact]
        public async Task GetUserAchievement_JavascriptCourseCompletedAchievementAndUserCompletedTwoCoursesOneBeingJavascript_ReturnsUserAchievementDTOWithIsCompletedEqualToTrue()
        {
            //Arrange
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetAchievementById(1))
                .ReturnsAsync(new Achievement
                {
                    AchievementId = 1,
                    Name = "Javascript Course Completed",
                    Type = AchievementType.Course,
                    Units = 1,
                    CourseId = 1
                });
            mimoTestRepo.Setup(m => m.GetUserWithCourseCompleted(1, 1))
                .ReturnsAsync(new User
                {
                    UserId = 1,
                    FirstName = It.IsAny<string>(),
                    LastName = It.IsAny<string>(),
                    CourseProgress = new List<CourseProgress>()
                    {
                        new CourseProgress
                        {
                            CourseId = 1,
                            ChapterId = null,
                            LessonId = null,
                            UserId = 1,
                            StartDateTime = It.IsNotNull<DateTime>(),
                            EndDateTime = It.IsNotNull<DateTime>(),
                        },
                        new CourseProgress
                        {
                            CourseId = 2,
                            ChapterId = null,
                            LessonId = null,
                            UserId = 1,
                            StartDateTime = It.IsNotNull<DateTime>(),
                            EndDateTime = It.IsNotNull<DateTime>(),
                        },
                    }
                });
            var achievementService = new AchievementService(mimoTestRepo.Object);

            //Act
            var achievement = await achievementService.GetUserAchievement(1, 1);

            //Assert
            Assert.IsType<UserAchievementDTO>(achievement);
            Assert.True(achievement.IsCompleted);
        }

        [Fact]
        public async Task GetUserAchievement_JavascriptCourseCompletedAchievementAndUserCompletedTwoCoursesOneBeingJavascript_ReturnsUserAchievementDTOWithProgressEqualToTwo()
        {
            //Arrange
            var mimoTestRepo = new Mock<IMimoRepository>();
            mimoTestRepo.Setup(m => m.GetAchievementById(1))
                .ReturnsAsync(new Achievement
                {
                    AchievementId = 1,
                    Name = "Javascript Course Completed",
                    Type = AchievementType.Course,
                    Units = 1,
                    CourseId = 1
                });
            mimoTestRepo.Setup(m => m.GetUserWithCourseCompleted(1, 1))
                .ReturnsAsync(new User
                {
                    UserId = 1,
                    FirstName = It.IsAny<string>(),
                    LastName = It.IsAny<string>(),
                    CourseProgress = new List<CourseProgress>()
                    {
                        new CourseProgress
                        {
                            CourseId = 1,
                            ChapterId = null,
                            LessonId = null,
                            UserId = 1,
                            StartDateTime = It.IsNotNull<DateTime>(),
                            EndDateTime = It.IsNotNull<DateTime>(),
                        },
                        new CourseProgress
                        {
                            CourseId = 2,
                            ChapterId = null,
                            LessonId = null,
                            UserId = 1,
                            StartDateTime = It.IsNotNull<DateTime>(),
                            EndDateTime = It.IsNotNull<DateTime>(),
                        },
                    }
                });
            var achievementService = new AchievementService(mimoTestRepo.Object);

            //Act
            var achievement = await achievementService.GetUserAchievement(1, 1);

            //Assert
            Assert.IsType<UserAchievementDTO>(achievement);
            Assert.Equal(2, achievement.Progress);
        }
    }

}