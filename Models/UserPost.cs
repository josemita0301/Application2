namespace Auth0_Blazor.Models
{
    public class UserPost
    {
        public string UserPostId { get; set; }
        public string CraftName { get; set; }
        public int Difficulty { get; set; }
        public string EventDate { get; set; }
        public string EventName { get; set; }
        public bool IsPublic { get; set; }
        public string PostDescription { get; set; }
        public string PublishDate { get; set; }
        public int Rating { get; set; }
        public int StepCount { get; set; }
        public string UserId { get; set; }
        public string VideoLink { get; set; }
        public List<string> Image { get; set; }
    }
}
