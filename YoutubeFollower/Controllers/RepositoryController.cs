using AutoMapper;
using DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using YoutubeFollower.Client;
using YoutubeFollower.Helpers;
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
        public async Task<ActionResult> AddChannel(string ChannelUrl)
        {
            var idPuller = new IdPuller();
            string Id = await idPuller.PullFrom(ChannelUrl);

            await _repository.AddChannelSnippet(Id);

            return Ok(Id);
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
