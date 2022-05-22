namespace YoutubeFollower.Models
{
    public class Statistics
    {
        public string ChannelId { get; set; }
        public string Name { get; set; }
        public List<StatisticsData> Data { get; set; }
        public class StatisticsData
        {
            public DateTime? Date { get; set; }
            public int ViewsCount { get; set; }
            public int SubscribersCount { get; set; }
            public int VideosCount { get; set; }

        }
    }
    
}
