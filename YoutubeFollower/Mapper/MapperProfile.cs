using AutoMapper;
using DataAccessLibrary.Models;
using YoutubeFollower.Models;

namespace YoutubeFollower.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ChannelVM, ChannelSnippet>()
                .ForMember(dest => dest.IsStared, opt => opt.MapFrom(src => false));
        }
    }
}
