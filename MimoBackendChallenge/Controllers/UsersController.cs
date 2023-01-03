using Microsoft.AspNetCore.Mvc;
using MimoBackendChallengeAPI.Models;
using MimoBackendChallengeAPI.Services;

namespace MimoBackendChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAchievementService achievementService;
        
        public UsersController(IAchievementService achievementService)
        {
            this.achievementService = achievementService;
        }

        [HttpGet("achievements")]
        public async Task<ActionResult<IEnumerable<UserAchievementDTO>>> GetUserAchievements()
        {
            //Using userId = 1 as we're not implementing an Authentication mechanism. Normally we would get the current user's id
            return await achievementService.GetUserAchievements(1);
        }

        [HttpGet("achievements/{achievementId}")]
        public async Task<IActionResult> GetUserAchievement(int achievementId)
        {
            var achievement = await achievementService.GetAchievementById(achievementId);
            if (achievement == null)
            {
                return NotFound();
            }
            //Using userId = 1 as we're not implementing an Authentication mechanism. Normally we would get the current user's id
            var userAchievement = await achievementService.GetUserAchievement(achievementId, 1);
            return Ok(userAchievement);
        }

    }
}
