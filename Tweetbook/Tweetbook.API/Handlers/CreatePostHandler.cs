using System.Threading;
using System.Threading.Tasks;
using Tweetbook.API.Commands;
using Tweetbook.Domain.Entities;
using Tweetbook.Application.Services;
using Tweetbook.Contracts.V1.Responses;
using AutoMapper;
using MediatR;

namespace Tweetbook.API.Handlers
{
    public class CreatePostHandler : IRequestHandler<CreatePostCommand, PostResponse>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public CreatePostHandler(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<PostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Name = request.Name
            };

            await _postService.CreatePostAsync(post);

            return _mapper.Map<PostResponse>(post);
        }
    }
}
