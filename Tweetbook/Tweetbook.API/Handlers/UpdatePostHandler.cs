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
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, PostResponse>
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public UpdatePostHandler(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<PostResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Id = request.PostId,
                Name = request.Name
            };

            var updated = await _postService.UpdatePostAsync(post);

            return updated
                ? _mapper.Map<PostResponse>(post)
                : null;
        }
    }
}
