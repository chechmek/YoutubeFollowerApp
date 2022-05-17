namespace YoutubeFollower.Json.Models
{
    public class ChannelRoot
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public ChannelJson[] items { get; set; }
    }

    public class ChannelJson
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public ChannelData snippet { get; set; }
        public Statistics statistics { get; set; }
    }

    public class ChannelData
    {
        public string title { get; set; }
        public string description { get; set; }
        public DateTime publishedAt { get; set; }
        public Thumbnails thumbnails { get; set; }
        public string country { get; set; }
    }

    public class Thumbnails
    {
        public Default _default { get; set; }
        public Medium medium { get; set; }
        public High high { get; set; }
    }

    public class Default
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Medium
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class High
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    public class Statistics
    {
        public string viewCount { get; set; }
        public string subscriberCount { get; set; }
        public string videoCount { get; set; }
    }

}
