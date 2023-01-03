using Microsoft.AspNetCore.Mvc;
using MimoBackendChallengeAPI.Models;
using MimoBackendChallengeAPI.Services;
using MimoDomain;

namespace MimoBackendChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService courseService;
        
        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpPost("{courseId}/progress")]
        public async Task<IActionResult> SendProgress(int courseId, LessonProgressAddDTO lessonProgress)
        {
            var course = await courseService.GetCourseById(courseId);
            var lesson = await courseService.GetLessonWithChapter(lessonProgress.LessonId);
            if (course == null)
            {
                return NotFound();
            }
            if (courseId != lesson?.Chapter.CourseId)
            {
                return BadRequest();
            }
            //Using userId = 1 as we're not implementing an Authentication mechanism. Normally we would get the current user's id
            var isAdded = await courseService.AddProgress(courseId, 1, lessonProgress);
            if (!isAdded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProgressDTO { isAdded = false });
            }

            await courseService.CheckChapterCompletion(lesson, lessonProgress.StartDateTime, lessonProgress.EndDateTime, 1);
            await courseService.CheckCourseCompletion(lesson.Chapter, lessonProgress.StartDateTime, lessonProgress.EndDateTime, 1);

            return Ok(new ProgressDTO { isAdded = true });
        }
    }
}
