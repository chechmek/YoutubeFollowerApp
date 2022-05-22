using YoutubeFollower.Models;

namespace YoutubeFollower.Client
{
    public class FakeYoutubeClient : IYoutubeClient
    {
        private Random _random { get; set; }
        public FakeYoutubeClient()
        {
            _random = new Random();
        }
        public async Task<Channel> GetChannelAsync(string channelId)
        {
            return new Channel
            {
                Id = channelId,
                Title = "test" + _random.Next(0, 100),
                videoCount = _random.Next(0, 100),
                viewCount = _random.Next(100, 100000),
                Country = "UA",
                subscriberCount = _random.Next(0, 999999),
                Comments = new List<Comment>
                {
                    new Comment{ Text = "comment"+_random.Next(0,100), AuthorName="fakeClient", LikeCount = _random.Next(0,50)},
                    new Comment{ Text = "comment"+_random.Next(0,100), AuthorName="fakeClient", LikeCount = _random.Next(0,50)},
                    new Comment{ Text = "comment"+_random.Next(0,100), AuthorName="fakeClient", LikeCount = _random.Next(0,50)}
                },
                Videos = new List<Video>
                {
                    new Video{ ChannelId = channelId, Title = "testVideo"+_random.Next(0,100)},
                    new Video{ ChannelId = channelId, Title = "testVideo"+_random.Next(0,100)},
                    new Video{ ChannelId = channelId, Title = "testVideo"+_random.Next(0,100)}
                }

            };
        }

        public async Task<Channel> GetChannelInfo(string channelId)
        {
            return new Channel
            {
                Id = channelId,
                Title = "test" + _random.Next(0, 100),
                videoCount = _random.Next(0, 100),
                viewCount = _random.Next(100, 100000),
                Country = "UA",
                subscriberCount = _random.Next(0, 999999),
            };
        }

        public async Task<List<Comment>> GetCommentsById(string channelId)
        {
            return new List<Comment>() { new Comment { Text = "fake comment)" } };
        }
    }
}
