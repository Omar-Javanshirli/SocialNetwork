using Azure;
using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Request;
using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Response;
using MediatR;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Handlers.QueryHandlers
{
    public class GetAllCommentLikeHandler:IRequestHandler<GetAllCommetnLikeRequest,Response<IEnumerable<GetAllCommentLikeResponse>>>
    {
    }
}
