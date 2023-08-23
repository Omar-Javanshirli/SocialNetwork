using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Shared.ControllerBases;
using SocialNetwork.Shared.Services;

namespace A._SocialNetwork.Services.Graph.Controllers
{
    [Route("api/[controller]")]
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
    }
}
