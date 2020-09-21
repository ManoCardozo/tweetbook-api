using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tweetbook.API.Queries;
using Tweetbook.Application.Services;
using Tweetbook.Contracts.V1.Responses;
using AutoMapper;
using MediatR;

namespace Tweetbook.API.Handlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsQuery, List<PostResponse>>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public GetPostsHandler(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public GetPostsHandler()
        {

        }

        public async Task<List<PostResponse>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postService.GetPostsAsync();

            return _mapper.Map<List<PostResponse>>(posts);
        }
    }
}
