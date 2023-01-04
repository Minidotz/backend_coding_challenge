using Microsoft.AspNetCore.Mvc;
using MimoBackendChallengeAPI.Controllers;
using MimoBackendChallengeAPI.Models;
using MimoBackendChallengeAPI.Services;
using MimoDomain;
using Moq;

namespace MimoBackendChallengeTests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task GetUserAchievement_ForValidAchievement_ReturnsUserAchievementDTO()
        {
            // Arrange
            var achievementServiceMock = new Mock<IAchievementService>();
            var achievementController = new UsersController(achievementServiceMock.Object);

            achievementServiceMock.Setup(m => m.GetAchievementById(1))
                .ReturnsAsync(new Achievement
                {
                    AchievementId = 1,
                    Name = It.IsAny<string>(),
                    Type = AchievementType.Lesson,
                    CourseId = null,
                    Course = null,
                    Units = 5
                });
            achievementServiceMock.Setup(m => m.GetUserAchievement(1, 1))
                .ReturnsAsync(new UserAchievementDTO
                {
                    AchievementId = 1,
                    IsCompleted = It.IsAny<bool>(),
                    Progress = It.IsAny<int>()
                });

            // Act
            var result = await achievementController.GetUserAchievement(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<UserAchievementDTO>(okResult.Value);
            Assert.Equal(1, returnValue.AchievementId);
        }

        [Fact]
        public async Task GetUserAchievement_ForNonExistingAchievement_ReturnsNotFound()
        {
            // Arrange
            var achievementServiceMock = new Mock<IAchievementService>();
            var achievementController = new UsersController(achievementServiceMock.Object);

            achievementServiceMock.Setup(m => m.GetAchievementById(12345))
                .ReturnsAsync((Achievement?) null);

            // Act
            var result = await achievementController.GetUserAchievement(12345);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}
