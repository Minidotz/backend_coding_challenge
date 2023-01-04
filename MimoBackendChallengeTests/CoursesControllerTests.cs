using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimoBackendChallengeAPI.Controllers;
using MimoBackendChallengeAPI.Models;
using MimoBackendChallengeAPI.Services;
using MimoDomain;
using Moq;

namespace MimoBackendChallengeTests
{
    public class CoursesControllerTests
    {
        [Fact]
        public async Task SendProgress_ForValidLessonAndCourse_ReturnsProgressDTOWithIsAddedEqualTrue()
        {
            // Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var courseController = new CoursesController(courseServiceMock.Object);

            var lessonProgress = new LessonProgressAddDTO
            {
                LessonId = 1,
                EndDateTime = DateTime.Now,
                StartDateTime = DateTime.Now,
            };

            courseServiceMock.Setup(m => m.GetCourseById(1))
                .ReturnsAsync(new Course
                {
                    CourseId = 1,
                    Name = It.IsAny<string>()
                });
            courseServiceMock.Setup(m => m.GetLessonWithChapter(lessonProgress.LessonId))
                .ReturnsAsync(new Lesson
                {
                    LessonId = 1,
                    Name = It.IsAny<string>(),
                    ChapterId = 1,
                    Chapter = new Chapter
                    {
                        ChapterId = 1,
                        Name = It.IsAny<string>(),
                        CourseId = 1,
                        Sort = 1
                    }
                });
            courseServiceMock.Setup(m => m.AddProgress(1, 1, lessonProgress))
                .ReturnsAsync(true);

            // Act
            var result = await courseController.SendProgress(1, lessonProgress);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ProgressDTO>(okResult.Value);
            Assert.True(returnValue.isAdded);
        }

        [Fact]
        public async Task SendProgress_ForValidLessonNonExistingCourse_ReturnsNotFound()
        {
            // Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var courseController = new CoursesController(courseServiceMock.Object);

            var lessonProgress = new LessonProgressAddDTO
            {
                LessonId = 1,
                EndDateTime = DateTime.Now,
                StartDateTime = DateTime.Now,
            };

            courseServiceMock.Setup(m => m.GetCourseById(12345))
                .ReturnsAsync((Course?) null);
            courseServiceMock.Setup(m => m.GetLessonWithChapter(lessonProgress.LessonId))
                .ReturnsAsync(new Lesson
                {
                    LessonId = 1,
                    Name = It.IsAny<string>(),
                    ChapterId = 1,
                    Chapter = new Chapter
                    {
                        ChapterId = 1,
                        Name = It.IsAny<string>(),
                        CourseId = 1,
                        Sort = 1
                    }
                });

            // Act
            var result = await courseController.SendProgress(1, lessonProgress);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task SendProgress_ForValidLessonDifferentCourse_ReturnsBadRequest()
        {
            // Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var courseController = new CoursesController(courseServiceMock.Object);

            var lessonProgress = new LessonProgressAddDTO
            {
                LessonId = 1,
                EndDateTime = DateTime.Now,
                StartDateTime = DateTime.Now,
            };

            courseServiceMock.Setup(m => m.GetCourseById(3))
                .ReturnsAsync(new Course
                {
                    CourseId = 3,
                    Name = It.IsAny<string>()
                });
            courseServiceMock.Setup(m => m.GetLessonWithChapter(lessonProgress.LessonId))
                .ReturnsAsync(new Lesson
                {
                    LessonId = 1,
                    Name = It.IsAny<string>(),
                    ChapterId = 1,
                    Chapter = new Chapter
                    {
                        ChapterId = 1,
                        Name = It.IsAny<string>(),
                        CourseId = 1,
                        Sort = 1
                    }
                });

            // Act
            var result = await courseController.SendProgress(3, lessonProgress);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task SendProgress_ForNonExistingLessonAndValidCourse_ReturnsBadRequest()
        {
            // Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var courseController = new CoursesController(courseServiceMock.Object);

            var lessonProgress = new LessonProgressAddDTO
            {
                LessonId = 1,
                EndDateTime = DateTime.Now,
                StartDateTime = DateTime.Now,
            };

            courseServiceMock.Setup(m => m.GetCourseById(lessonProgress.LessonId))
                .ReturnsAsync(new Course
                {
                    CourseId = 1,
                    Name = It.IsAny<string>()
                });
            courseServiceMock.Setup(m => m.GetLessonWithChapter(lessonProgress.LessonId))
                .ReturnsAsync((Lesson?) null);

            // Act
            var result = await courseController.SendProgress(1, lessonProgress);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task SendProgress_ForValidLessonAndCourseAndAddProgressReturnsFalse_ReturnsStatusCode500ProgressDTOWithIsAddedEqualFalse()
        {
            // Arrange
            var courseServiceMock = new Mock<ICourseService>();
            var courseController = new CoursesController(courseServiceMock.Object);

            var lessonProgress = new LessonProgressAddDTO
            {
                LessonId = 1,
                EndDateTime = DateTime.Now,
                StartDateTime = DateTime.Now,
            };

            courseServiceMock.Setup(m => m.GetCourseById(1))
                .ReturnsAsync(new Course
                {
                    CourseId = 1,
                    Name = It.IsAny<string>()
                });
            courseServiceMock.Setup(m => m.GetLessonWithChapter(lessonProgress.LessonId))
                .ReturnsAsync(new Lesson
                {
                    LessonId = 1,
                    Name = It.IsAny<string>(),
                    ChapterId = 1,
                    Chapter = new Chapter
                    {
                        ChapterId = 1,
                        Name = It.IsAny<string>(),
                        CourseId = 1,
                        Sort = 1
                    }
                });
            courseServiceMock.Setup(m => m.AddProgress(1, 1, lessonProgress))
                .ReturnsAsync(false);

            // Act
            var result = await courseController.SendProgress(1, lessonProgress);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            var statusCode = objectResult.StatusCode;
            var returnValue = Assert.IsType<ProgressDTO>(objectResult.Value);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCode);
            Assert.False(returnValue.isAdded);
        }
    }
}
