using MimoBackendChallengeAPI.Models;
using MimoData;
using MimoData.Repositories;
using MimoDomain;

namespace MimoBackendChallengeAPI.Services
{
    public class AchievementService : IAchievementService
    {
        private readonly IMimoRepository mimoRepository;

        public AchievementService(IMimoRepository repository)
        {
            mimoRepository = repository;
        }

        public async Task<Achievement?> GetAchievementById(int achievementId)
        {
            return await mimoRepository.GetAchievementById(achievementId);
        }

        public async Task<List<UserAchievementDTO>> GetUserAchievements(int userId)
        {
            List<UserAchievementDTO> userAchievements = new List<UserAchievementDTO>();
            var achievements = await mimoRepository.GetAchievements();
            foreach (var achievement in achievements)
            {
                var achievementProgress = await GetAchievementProgress(achievement, userId);
                userAchievements.Add(new UserAchievementDTO
                {
                    AchievementId = achievement.AchievementId,
                    IsCompleted = achievementProgress.IsCompleted,
                    Progress = achievementProgress.CompletedItems
                });
            }
            return userAchievements;
        }

        public async Task<UserAchievementDTO> GetUserAchievement(int achievementId, int userId)
        {
            var achievement = await mimoRepository.GetAchievementById(achievementId);
            var achievementProgress = await GetAchievementProgress(achievement, userId);
            return new UserAchievementDTO
            {
                AchievementId = achievementId,
                IsCompleted = achievementProgress.IsCompleted,
                Progress = achievementProgress.CompletedItems
            };
        }


        private async Task<AchievementProgressModel> GetAchievementProgress(Achievement achievement, int userId)
        {
            int completedItems = 0;
            switch (achievement.Type)
            {
                case AchievementType.Course:
                    {
                        User? userWithCourseProgress = null;
                        //Tracking number of courses completed
                        if (achievement.CourseId == null)
                        {
                            userWithCourseProgress = await mimoRepository.GetUserWithCoursesCompleted(userId);
                        }
                        //Tracking if specific course is completed
                        else
                        {
                            userWithCourseProgress = await mimoRepository.GetUserWithCourseCompleted(userId, achievement.CourseId);
                        }

                        completedItems = userWithCourseProgress?.CourseProgress.Count ?? 0;
                        break;
                    }
                case AchievementType.Chapter:
                    {
                        var userWithCourseProgress = await mimoRepository.GetUserWithChaptersCompleted(userId);

                        completedItems = userWithCourseProgress?.CourseProgress.Count ?? 0;
                        break;
                    }
                case AchievementType.Lesson:
                    {
                        var userWithCourseProgress = await mimoRepository.GetUserWithLessonsCompleted(userId);

                        completedItems = userWithCourseProgress?.CourseProgress.Count ?? 0;
                        break;
                    }
            }
            return new AchievementProgressModel
            {
                CompletedItems = completedItems,
                IsCompleted = IsAchievementCompleted(achievement.Units, completedItems)
            };
        }

        private bool IsAchievementCompleted(int targetNumber, int numOfLessons)
        {
            return numOfLessons >= targetNumber ? true : false;
        }
    }
}
