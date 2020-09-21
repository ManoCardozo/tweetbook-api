using System;
using Tweetbook.Contracts.V1.Responses;
using MediatR;

namespace Tweetbook.API.Queries
{
    public class GetPostByIdQuery : IRequest<PostResponse>
    {
        public Guid PostId { get; }

        public GetPostByIdQuery(Guid id)
        {
            PostId = id;
        }
    }
}
