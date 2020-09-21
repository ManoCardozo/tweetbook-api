using MediatR;
using Tweetbook.Contracts.V1.Responses;

namespace Tweetbook.API.Commands
{
    public class CreatePostCommand : IRequest<PostResponse>
    {
        public string Name { get; set; }
    }
}
