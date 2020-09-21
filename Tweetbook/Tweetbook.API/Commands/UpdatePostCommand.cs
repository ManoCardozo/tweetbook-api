using System;
using Tweetbook.Contracts.V1.Responses;
using MediatR;

namespace Tweetbook.API.Commands
{
    public class UpdatePostCommand : IRequest<PostResponse>
    {
        public Guid PostId { get; set; }

        public string Name { get; set; }
    }
}
