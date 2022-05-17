namespace YoutubeFollower.Models
{
    public class Comment
    {
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public int LikeCount { get; set; }
        public DateTime Date { get; set; }
    }
}
