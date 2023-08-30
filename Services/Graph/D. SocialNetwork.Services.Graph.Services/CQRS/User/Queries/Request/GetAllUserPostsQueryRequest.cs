using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Request
{
    public class GetAllUserPostsQueryRequest : IRequest<Response<IEnumerable<GetAllUserPostsQueryResponse>>>
    {
        public Guid UserId { get; set; }

        public GetAllUserPostsQueryRequest(Guid userId )
        {
            UserId = userId;
        }
    }
}
