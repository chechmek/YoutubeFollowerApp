using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Models;
using YoutubeFollower.Client;
using YoutubeFollower.Exceptions;
using YoutubeFollower.Json;
using YoutubeFollower.Models;
using YoutubeFollower.Tracker;

namespace YoutubeFollower.Repository
{
    public class FollowerRepository : IFollowerRepository
    {
        private FollowerDbContext _context { get; }
        private IYoutubeClient _client { get; }

        public FollowerRepository(FollowerDbContext context, IYoutubeClient client)
        {
            _context = context;
            _client = client;
        }
        public List<ChannelSnippet> GetAllChannels()
        {
            var channels = _context.Channels.ToList();
            if(channels is null)
                throw new NoChannelsException();

            return channels;
        }
        public ChannelSnippet GetStaredChannel()
        {
            if (_context.Channels.ToList().Count == 0)
                throw new NoChannelsException();
            var starredChannnel = _context.Channels.Where(ch => ch.IsStared).FirstOrDefault();
            if (starredChannnel is null)
                starredChannnel = _context.Channels.FirstOrDefault();
            if (starredChannnel is null)
                throw new ChannelNotExistsException();
            return starredChannnel;
        }
        public async Task AddChannelSnippet(string channelId)
        {
            var channel = new Channel();
            //var client = new YoutubeClient(new HttpClient(), new JsonConverter());
            try
            {
                channel = await _client.GetChannelInfo(channelId);
            }
            catch 
            {
                throw new ChannelNotExistsException();
            }
            try
            {
                var channelSnippet = new ChannelSnippet
                {
                    Id = channel.Id,
                    Name = channel.Title,
                    IsStared = false
                };
                _context.Channels.Add(channelSnippet);
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (_context.Channels.Any(ch => ch.Id == channelId))
                {
                    throw new ChannelAlreadyExistsException();
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task RemoveChannelSnippet(string channelId)
        {
            try
            {
                _context.Channels.Remove(new ChannelSnippet() { Id = channelId });
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (!_context.Channels.Any(ch => ch.Id == channelId))
                {
                    throw new ChannelNotExistsException();
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task MakeStared(string channelId)
        {
            try //  Unstar everything before? (Mb too expensive)
            {
                UnStarAll();
                var channel = _context.Channels.FirstOrDefault(ch => ch.Id == channelId);
                channel.IsStared = true;
                await _context.SaveChangesAsync();  
            }
            catch 
            {
                if (!_context.Channels.Any(ch => ch.Id == channelId))
                {
                    throw new ChannelNotExistsException();
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task MakeUnStared(string channelId)
        {
            try
            {
                var channel = _context.Channels.FirstOrDefault(ch => ch.Id == channelId);
                channel.IsStared = false;
                await _context.SaveChangesAsync();
            }
            catch
            {
                if (_context.Channels.Any(ch => ch.Id == channelId))
                {
                    throw new ChannelNotExistsException();
                }
                else
                {
                    throw;
                }
            }
        }
        private void UnStarAll()
        {
            foreach (var channel in _context.Channels)
            {
                channel.IsStared = false;
            }
        }
    }
}
