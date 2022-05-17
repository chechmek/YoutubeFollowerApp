using YoutubeFollower.Models;

namespace YoutubeFollower.Json
{
    public interface IJsonConverter
    {
        Channel ConvertChannel(string json);
        List<Comment> ConvertCommentList(string json);
        List<Video> ConvertVideoList(string json);
    }
}