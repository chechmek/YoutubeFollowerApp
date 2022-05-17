namespace YoutubeFollower.Json.Models
{

    public class VideoRoot
    {
        public VideoJson[] items { get; set; }
    }
    public class VideoJson
    {
        public string kind { get; set; }
        public Id id { get; set; }
        public VideoData snippet { get; set; }
    }

    public class Id
    {
        public string kind { get; set; }
        public string videoId { get; set; }
    }

    public class VideoData
    {
        public DateTime publishedAt { get; set; }
        public string channelId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Thumbnails thumbnails { get; set; }
        public string channelTitle { get; set; }
        public string liveBroadcastContent { get; set; }
        public DateTime publishTime { get; set; }
    }

   
}