using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Request
{
    public class GetAllCommentLikeRequest : IRequest<Response<IEnumerable<GetAllCommentLikeResponse>>>
    {
        public GetAllCommentLikeRequest(Guid commentId)
        {
            CommentId = commentId;
        }

        public Guid CommentId { get; set; }
    }
}
