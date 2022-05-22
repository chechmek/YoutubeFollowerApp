using YoutubeFollower.Exceptions;
using YoutubeFollower.Json;
using YoutubeFollower.Models;

namespace YoutubeFollower.Client
{
    //  How to set up visual studio auto formatinng, is it possible?
    //  ChannelTracker: so in stackoverflow i red that i used an anti-pattern, but there are no way to avoid it. And what i actually did?)
    public class YoutubeClient : IYoutubeClient
    {
        private const string API_KEY = "AIzaSyB19QL3O1VJPWOnAqAJuvjWQkXBLxQ6TBI";
        private const string URL = "https://www.googleapis.com/youtube/v3/";
        private HttpClient _client { get; }
        private IJsonConverter _jsonConverter { get; }
        public YoutubeClient(HttpClient client, IJsonConverter jsonConverter)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _jsonConverter = jsonConverter ?? throw new ArgumentNullException(nameof(jsonConverter));
        }
        public async Task<Channel> GetChannelAsync(string channelId)
        {
            var channel = GetChannelInfo(channelId);
            var videos = GetVideosById(channelId);
            var comments = GetCommentsById(channelId);

            await Task.WhenAll(channel, videos, comments);

            channel.Result.Comments = comments.Result;
            channel.Result.Videos = videos.Result;

            return channel.Result;
        }
        //Sample link: https://www.googleapis.com/youtube/v3/channels?part=snippet%2CcontentDetails%2Cstatistics&id=UCRbni8punxajnQgnuOjfbyg&key=AIzaSyB19QL3O1VJPWOnAqAJuvjWQkXBLxQ6TBI
        public async Task<Channel> GetChannelInfo(string channelId) //UCRbni8punxajnQgnuOjfbyg
        {
            string url = $"{URL}channels?part=snippet%2CcontentDetails%2Cstatistics&id={channelId}&key={API_KEY}";

            try
            {
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var responceJson = await response.Content.ReadAsStringAsync();
                var channel = _jsonConverter.ConvertChannel(responceJson);

                return channel;
            }
            catch
            {

                throw new ChannelNotExistsException();
            }
            
        }
        public async Task<List<Video>> GetVideosById(string channelId)
        {
            string url = $"{URL}search?key={API_KEY}&channelId={channelId}&part=snippet,id&order=date&maxResults=20";

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var videos = _jsonConverter.ConvertVideoList(await response.Content.ReadAsStringAsync());

            return videos;
        }

        public async Task<List<Comment>> GetCommentsById(string channelId)
        {
            string url = $"https://youtube.googleapis.com/youtube/v3/commentThreads?part=snippet%2Creplies&allThreadsRelatedToChannelId={channelId}&key={API_KEY}";

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var comments = _jsonConverter.ConvertCommentList(await response.Content.ReadAsStringAsync());

            return comments;
        }
    }
}
