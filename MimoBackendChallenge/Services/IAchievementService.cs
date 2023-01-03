using MimoBackendChallengeAPI.Models;
using MimoDomain;

namespace MimoBackendChallengeAPI.Services
{
    public interface IAchievementService
    {
        Task<Achievement?> GetAchievementById(int achievementId);
        Task<UserAchievementDTO> GetUserAchievement(int achievementId, int userId);
        Task<List<UserAchievementDTO>> GetUserAchievements(int userId);
    }
}