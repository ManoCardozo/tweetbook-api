using System;
using MediatR;

namespace Tweetbook.API.Commands
{
    public class DeletePostCommand : IRequest<bool>
    {
        public Guid PostId { get; }

        public DeletePostCommand(Guid id)
        {
            PostId = id;
        }
    }
}
