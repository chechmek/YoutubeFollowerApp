using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using YoutubeFollower.Client;
using YoutubeFollower.Repository;

namespace YoutubeFollower.Tracker
{
    public class ChannelTracker : BackgroundService
    {
        private const int TRACK_COOLDOWN = 10000;
        private IYoutubeClient _client { get; set; }
        private FollowerDbContext _context { get; set; }
        public ChannelTracker(IYoutubeClient client, IServiceScopeFactory factory)
        {
            _client = client;
            _context = factory.CreateScope().ServiceProvider.GetRequiredService<FollowerDbContext>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TRACK_COOLDOWN, stoppingToken);

                    var channelList = _context.Channels.ToList();

                    foreach (var channel in channelList)
                    {
                        var channelInfo = await _client.GetChannelInfo(channel.Id);
                        if (channelInfo != null)
                        {
                            _context.Statistic.Add(new StatisticsDb
                            {
                                Date = DateTime.Now,
                                ChannelId = channelInfo.Id,
                                SubscriberCount = channelInfo.subscriberCount,
                                VideosCount = channelInfo.videoCount,
                                ViewCount = channelInfo.viewCount
                            });
                            Console.WriteLine($"Adding: {channelInfo.Id}, view count = {channelInfo.videoCount}, subscribers = {channelInfo.subscriberCount}");
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    Console.WriteLine("Uhh, channel tracker said goodbye...");
                }
                

                
            }
        }
    }
}
