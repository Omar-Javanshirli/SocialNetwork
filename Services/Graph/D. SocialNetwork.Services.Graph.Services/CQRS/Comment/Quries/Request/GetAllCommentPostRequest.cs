using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Request
{
    public class GetAllCommentPostRequest : IRequest<Response<IEnumerable<GetAllCommentPostResponse>>>
    {
        public Guid PostId { get; set; }

        public GetAllCommentPostRequest(Guid postId)
        {
            PostId = postId;
        }
    }
}
