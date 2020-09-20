using AutoMapper;
using Tweetbook.API.Domain;
using Tweetbook.API.Contracts.V1.Responses;

namespace Tweetbook.API.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Post, PostResponse>();
        }
    }
}
