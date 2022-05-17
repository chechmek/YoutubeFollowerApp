using YoutubeFollower.Models;

namespace YoutubeFollower.Client
{
    public interface IYoutubeClient
    {
        Task<Channel> GetChannelAsync(string channelId);
    }
}
