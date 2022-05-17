using System.Text.Json;
using YoutubeFollower.Json.Models;
using YoutubeFollower.Models;

namespace YoutubeFollower.Json
{
    public class JsonConverter : IJsonConverter
    {
        public Channel ConvertChannel(string json)
        {
            ChannelRoot? root = JsonSerializer.Deserialize<ChannelRoot>(json)
                ?? throw new NullReferenceException();
            if (root.items is null) throw new NullReferenceException();
            ChannelJson channelJson = root.items.FirstOrDefault() ?? throw new NullReferenceException();
            Channel channel = new Channel
            {
                Id = channelJson.id,
                Title = channelJson.snippet.title,
                Description = channelJson.snippet.description,
                CreateDate = channelJson.snippet.publishedAt,
                Country = channelJson.snippet.country,
                viewCount = Convert.ToInt32(channelJson.statistics.viewCount),
                subscriberCount = Convert.ToInt32(channelJson.statistics.subscriberCount),
                videoCount = Convert.ToInt32(channelJson.statistics.videoCount),
                MediumThumbnail = channelJson.snippet.thumbnails.medium.url,
                HighThumbnail = channelJson.snippet.thumbnails.high.url
            };
            return channel;
        }
        public List<Comment> ConvertCommentList(string json)
        {
            var comments = new List<Comment>();
            var commentRoot = JsonSerializer.Deserialize<CommentRoot>(json) ?? throw new NullReferenceException();

            foreach (var comment in commentRoot.items ?? throw new NullReferenceException())
            {
                comments.Add(new Comment
                {
                    Text = comment.snippet.topLevelComment.snippet.textDisplay,
                    AuthorName = comment.snippet.topLevelComment.snippet.authorDisplayName,
                    LikeCount = comment.snippet.topLevelComment.snippet.likeCount,
                    Date = comment.snippet.topLevelComment.snippet.publishedAt
                });
            }

            if (comments.Count == 0) return null;
            return comments;
        }
        public List<Video> ConvertVideoList(string json)
        {
            var videos = new List<Video>();
            VideoRoot? root = JsonSerializer.Deserialize<VideoRoot>(json)
                ?? throw new NullReferenceException();
            if (root.items.Length == 0 || root.items is null) return null;

            foreach (var video in root.items)
            {
                videos.Add(new Video
                {
                    Id = video.id.videoId,
                    Title = video.snippet.title,
                    CreateDate = video.snippet.publishedAt,
                    ChannelId = video.snippet.channelId,
                    ChannelTitle = video.snippet.channelTitle,
                    MediumThumbnail = video.snippet.thumbnails.medium.url,
                    HighThumbnail = video.snippet.thumbnails.high.url
                });
            }
            return videos;
        }
    }
}
