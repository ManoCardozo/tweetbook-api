using System.Threading;
using System.Threading.Tasks;
using Tweetbook.API.Queries;
using Tweetbook.Application.Services;
using Tweetbook.Contracts.V1.Responses;
using AutoMapper;
using MediatR;

namespace Tweetbook.API.Handlers
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, PostResponse>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public GetPostByIdHandler(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<PostResponse> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postService.GetPostByIdAsync(request.PostId);

            return post == null 
                ? null
                : _mapper.Map<PostResponse>(post);
        }
    }
}
