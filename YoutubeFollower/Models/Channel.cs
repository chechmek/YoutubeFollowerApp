namespace YoutubeFollower.Models
{
    public class Channel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string Country { get; set; }
        public int viewCount { get; set; }
        public int subscriberCount { get; set; }
        public int videoCount { get; set; }
        public string HighThumbnail { get; set; }
        public string MediumThumbnail { get; set; }
        public List<Video> Videos { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
