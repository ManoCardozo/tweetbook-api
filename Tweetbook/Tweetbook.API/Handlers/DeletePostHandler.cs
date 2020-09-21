using System.Threading;
using System.Threading.Tasks;
using Tweetbook.API.Commands;
using Tweetbook.Application.Services;
using MediatR;

namespace Tweetbook.API.Handlers
{
    public class DeletePostHandler : IRequestHandler<DeletePostCommand, bool>
    {
        private readonly IPostService _postService;

        public DeletePostHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            return await _postService.DeletePostAsync(request.PostId);
        }
    }
}
