using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Shared.ControllerBases;

namespace A._SocialNetwork.Services.Graph.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public GraphController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserPosts(string userId)
        {
            var request = new GetAllUserPostsQueryRequest(userId);
            return CreateActionResult(await _mediator.Send(request));
        }
    }
}
