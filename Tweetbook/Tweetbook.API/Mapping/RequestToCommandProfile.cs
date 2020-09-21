using AutoMapper;
using Tweetbook.API.Commands;
using Tweetbook.Contracts.V1.Requests;

namespace Tweetbook.API.Mapping
{
    public class RequestToCommandProfile : Profile
    {
        public RequestToCommandProfile()
        {
            CreateMap<CreatePostRequest, CreatePostCommand>();
            CreateMap<UpdatePostCommand, UpdatePostCommand>();
        }
    }
}
