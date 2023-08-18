using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Request
{
    public class GetAllUserPostsQueryRequest : IRequest<Response<IEnumerable<GetAllUserPostsQueryResponse>>
    {
        public string UserId { get; set; }

        public GetAllUserPostsQueryRequest(string userId)
        {
            UserId = userId;
        }
    }
}
