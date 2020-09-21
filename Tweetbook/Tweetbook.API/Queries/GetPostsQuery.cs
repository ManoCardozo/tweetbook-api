using MediatR;
using System.Collections.Generic;
using Tweetbook.Contracts.V1.Responses;

namespace Tweetbook.API.Queries
{
    public class GetPostsQuery : IRequest<List<PostResponse>>
    {

    }
}
