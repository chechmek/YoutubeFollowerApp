namespace YoutubeFollower.Models
{
    public class Video
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        public string HighThumbnail { get; set; }
        public string MediumThumbnail { get; set; }
    }
}
