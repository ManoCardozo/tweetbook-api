﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tweetbook.API.Queries;
using Tweetbook.API.Commands;
using Tweetbook.Contracts.V1;
using Tweetbook.Contracts.V1.Requests;
using AutoMapper;
using MediatR;

namespace Tweetbook.API.Controllers.V1
{
    public class PostsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PostsController(
            IMapper mapper, 
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> GetAsync([FromRoute] Guid postId)
        {
            var query = new GetPostByIdQuery(postId);

            var response = await _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetPostsQuery();
            
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid postId, [FromBody] UpdatePostRequest request)
        {
            var command = _mapper.Map<UpdatePostCommand>(request);
            command.PostId = postId;

            var response = await _mediator.Send(command);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePostRequest request)
        {
            var command = _mapper.Map<CreatePostCommand>(request);

            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid postId)
        {
            var command = new DeletePostCommand(postId);

            var deleted = await _mediator.Send(command);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
