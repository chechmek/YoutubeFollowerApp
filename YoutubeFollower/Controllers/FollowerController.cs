using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YoutubeFollower.Client;
using YoutubeFollower.Models;
using YoutubeFollower.Repository;

namespace YoutubeFollower.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private IYoutubeClient _client { get; }
        private IFollowerRepository _repository { get; }

        public FollowerController(IYoutubeClient client, IFollowerRepository repository)
        {
            _client = client;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Channel>> Channel(string Id)
        {
            var channel = await _client.GetChannelAsync(Id);
            return Ok(channel);
        }
        [HttpGet]
        public async Task<ActionResult<Channel>> MainChannel()
        {
            var channelSnippet = _repository.GetStaredChannel();

            var channel = await _client.GetChannelAsync(channelSnippet.Id);

            return Ok(channel);
        }

    }
}
