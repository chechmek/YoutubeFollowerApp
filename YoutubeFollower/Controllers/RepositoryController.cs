using AutoMapper;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using YoutubeFollower.Client;
using YoutubeFollower.Models;
using YoutubeFollower.Repository;

namespace YoutubeFollower.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private IFollowerRepository _repository { get; }
        private IMapper _mapper { get; }
        private IYoutubeClient _client { get; }
        public RepositoryController(IFollowerRepository repository, IMapper mapper, IYoutubeClient client)
        {
            _repository = repository;
            _mapper = mapper;
            _client = client;
        }
        [HttpGet]
        public async Task<ActionResult<List<ChannelSnippet>>> AllChannels()
        {
            var channels = _repository.GetAllChannels();

            return Ok(channels);
        }
        [HttpPost]
        public async Task<ActionResult> AddChannel(ChannelVM channelVM)
        {
            var channelSnippet = _mapper.Map<ChannelSnippet>(channelVM);

            await _repository.AddChannelSnippet(channelSnippet);

            return Ok(channelSnippet);
        }
        [HttpDelete]
        public async Task<ActionResult> RemoveChannel(string Id)
        {
            await _repository.RemoveChannelSnippet(Id);

            return Ok(Id);
        }
        [HttpPost]
        public async Task<ActionResult> Star(string Id)
        {
            await _repository.MakeStared(Id);

            return Ok(Id);
        }
        [HttpPost]
        public async Task<ActionResult> UnStar(string Id)
        {
            await _repository.MakeUnStared(Id);

            return Ok(Id);
        }
    }
}
