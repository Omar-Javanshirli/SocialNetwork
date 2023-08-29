using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Response
{
    public class GetAllUserPostsQueryResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
