﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tweetbook.API.Domain;
using Tweetbook.API.Services;
using Tweetbook.API.Contracts.V1;
using Tweetbook.API.Contracts.Requests;
using Tweetbook.API.Contracts.Responses;

namespace Tweetbook.API.Controllers.V1
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _postService.GetPostsAsync());
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
        {
            var post = new Post
            {
                Id = postId,
                Name = request.Name
            };

            var updated = await _postService.UpdatePostAsync(post);

            if (!updated)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post 
            { 
                Name = postRequest.Name 
            };

            await _postService.CreatePostAsync(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var location = baseUrl + "/" + ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString());

            var response = new PostResponse { Id = post.Id };

            return Created(location, response);
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid postId)
        {
            var deleted = await _postService.DeletePostAsync(postId);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
