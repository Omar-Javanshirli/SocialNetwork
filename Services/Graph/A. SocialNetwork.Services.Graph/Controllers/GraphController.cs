using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Handlers.QueryHandlers;
using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Request;
using D._SocialNetwork.Services.Graph.Services.CQRS.Post.Queries.Request;
using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Shared.ControllerBases;
using SocialNetwork.Shared.Services;

namespace A._SocialNetwork.Services.Graph.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GraphController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;
        public GraphController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserPosts()
        {
            var request = new GetAllUserPostsQueryRequest(_sharedIdentityService.GetUserId);
            return CreateActionResult(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllUsersPostLike(Guid postId)
        {
            var request = new GetAllUsersPostLikeQueryRequest(postId);
            return CreateActionResult(await _mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllCommentForPost(Guid postId)
        {
            var request = new GetAllCommentPostRequest(postId);
            return CreateActionResult(await _mediator.Send(request));
        }
    }
}
