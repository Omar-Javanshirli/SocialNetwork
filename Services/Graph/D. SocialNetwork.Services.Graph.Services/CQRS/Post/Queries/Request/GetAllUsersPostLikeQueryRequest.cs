using D._SocialNetwork.Services.Graph.Services.CQRS.Post.Queries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.Post.Queries.Request
{
    public class GetAllUsersPostLikeQueryRequest: IRequest<Response<IEnumerable<GetAllUsersPostLikeQueryResponse>>>
    {
        public string PostId { get; set; }

        public GetAllUsersPostLikeQueryRequest(string postId)
        {
            PostId=postId;
        }
    }
}
