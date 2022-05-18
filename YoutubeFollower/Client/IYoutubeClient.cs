using YoutubeFollower.Models;

namespace YoutubeFollower.Client
{
    public interface IYoutubeClient
    {
        Task<Channel> GetChannelAsync(string channelId); // Gets channel with videos and comments
        Task<Channel> GetChannelInfo(string channelId); //  Gets only channel
    }
}
