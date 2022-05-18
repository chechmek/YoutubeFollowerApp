using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using YoutubeFollower.Client;
using YoutubeFollower.Exceptions;
using YoutubeFollower.Json;
using YoutubeFollower.Models;

namespace YoutubeFollowerTests
{
    public class YoutubeClientTests
    {
        private YoutubeClient _ytclient { get; }
        public YoutubeClientTests()
        {
            _ytclient = new YoutubeClient(new HttpClient(), new JsonConverter());
        }
        [Fact]
        public async Task GetChannel_Success()
        {
            string channelid = TestData.ChannelId;
            var expected = TestData.ChechmekChannel;

            var actual = await _ytclient.GetChannelInfo(channelid);

            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Title, actual.Title);
            Assert.NotNull(actual);
            Assert.True(actual.subscriberCount != 0);
        }
        [Fact]
        public async Task GetVideosById_Success()
        {
            string channelid = TestData.ChannelId;
            
            var actual = await _ytclient.GetVideosById(channelid);

            Assert.NotNull(actual);
            if (actual.Count != 0)
            {
                Assert.NotNull(actual[0].Id);
                Assert.NotNull(actual[0].Title);
                Assert.NotNull(actual[0].MediumThumbnail);
            }
        }
        [Fact]
        public async Task GetCommentsById_Success()
        {
            string channelid = TestData.GordonChannelId;

            var actual = await _ytclient.GetCommentsById(channelid);

            Assert.NotNull(actual);
            Assert.True(actual.Count > 0);
            Assert.NotNull(actual[0].Text);
            Assert.NotNull(actual[0].AuthorName);
            Assert.True(actual[0].LikeCount >= 0);
            
        }
        [Fact]
        public async Task GetCommentsById_ReturnNull()
        {
            string channelid = TestData.ChannelIdWithoutContent;

            var actual = await _ytclient.GetCommentsById(channelid);


        }
        [Fact]
        public async Task GetVideosById_ReturnNull() //Channel without videos: UC87mLwjzs12oabpAxrGgunA 
        {
            string channelId = TestData.ChannelIdWithoutContent;

            var actual = await _ytclient.GetVideosById(channelId);  

            Assert.Null(actual);
        }
        [Theory]
        [InlineData("")]
        public async Task YoutubeClient_Exception(string channelid)
        {
            await Assert.ThrowsAsync<ChannelNotExistsException>(async () =>
            {
                await _ytclient.GetChannelAsync(channelid);
            });
        }
        //[Theory]
        //[InlineData("%&@#*(%+)#&%/'")]
        //public async Task YoutubeClient_BadRequest(string channelid)
        //{
        //    await Assert.ThrowsAsync<HttpRequestException>(async () =>
        //    {
        //        await _ytclient.GetChannelById(channelid);
        //        await _ytclient.GetVideosById(channelid);
        //        //await _ytclient.GetCommentsById(channelid);
        //    });
        //}
    }
}
