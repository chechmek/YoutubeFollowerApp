using DataAccessLibrary.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YoutubeFollower.Exceptions;
using YoutubeFollower.Models;
using static YoutubeFollower.Models.Statistics;

namespace YoutubeFollower.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private FollowerDbContext _context { get; }
        public StatisticsController(FollowerDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Statistics>> Channel(string channelId)
        {
            var stats = new Statistics();

            var statsDb = _context.Statistic.Where(ch => ch.ChannelId == channelId).ToList();
            if (statsDb == null) throw new ChannelNotExistsException();

            try
            {
                stats.ChannelId = statsDb[0].ChannelId;
                stats.Name = _context.Channels.FirstOrDefault(ch => ch.Id == channelId).Name;
                stats.Data = new List<StatisticsData>();
                foreach (var stat in statsDb)
                {
                    stats.Data.Add(new StatisticsData
                    {
                        Date = stat.Date,
                        VideosCount = stat.VideosCount,
                        ViewsCount = stat.ViewCount,
                        SubscribersCount = stat.SubscriberCount
                    });
                }
                    
            }
            catch 
            {
                throw new ChannelNotExistsException();
            }
            return stats;
        }

    }
}
