﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Tweetbook.API.Domain;

namespace Tweetbook.API.Services
{
    public interface IPostService
    {
        Task<Post> GetPostByIdAsync(Guid postId);

        Task<List<Post>> GetPostsAsync();

        Task<bool> CreatePostAsync(Post postToCreate);

        Task<bool> UpdatePostAsync(Post postToUpdate);

        Task<bool> DeletePostAsync(Guid postId);
    }
}