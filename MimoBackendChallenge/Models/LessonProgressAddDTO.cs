namespace MimoBackendChallengeAPI.Models
{
    public class LessonProgressAddDTO
    {
        public int LessonId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
