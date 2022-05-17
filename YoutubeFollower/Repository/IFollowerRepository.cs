using DataAccessLibrary.Models;

namespace YoutubeFollower.Repository
{
    public interface IFollowerRepository
    {
        List<ChannelSnippet> GetAllChannels();
        Task AddChannelSnippet(ChannelSnippet channelSnippet);
        Task RemoveChannelSnippet(string channelId);
        ChannelSnippet GetStaredChannel();
        Task MakeStared(string channelId);
        Task MakeUnStared(string channelId);
    }
}
