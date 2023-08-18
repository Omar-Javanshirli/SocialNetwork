using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace A._SocialNetwork.Services.Graph.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        private readonly IMediator mediator;

        public GraphController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult>GetAllUserPosts(string userId)
        {
            var request=new GetAllUserPostsQueryRequest
        }
    }
}
