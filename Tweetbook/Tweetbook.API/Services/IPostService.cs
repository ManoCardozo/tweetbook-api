using System;
using System.Collections.Generic;
using Tweetbook.API.Domain;

namespace Tweetbook.API.Services
{
    public interface IPostService
    {
        Post GetPostById(Guid postId);

        List<Post> GetPosts();

        bool UpdatePost(Post postToUpdate);

        bool DeletePost(Guid postId);
    }
}