using AutoMapper;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Request;
using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Handlers.QueryHandlers
{
    public class GetAllCommentLikeHandler : IRequestHandler<GetAllCommentLikeRequest, Response<IEnumerable<GetAllCommentLikeResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCommentLikeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllCommentLikeResponse>>> Handle(GetAllCommentLikeRequest request, CancellationToken cancellationToken)
        {
            var commentLikes = await _unitOfWork.commentRepository.GetAllCommentLike(request.CommentId);
            var response = _mapper.Map<IEnumerable<GetAllCommentLikeResponse>>(commentLikes);
            return Response<IEnumerable<GetAllCommentLikeResponse>>.Success(response, 200);
        }
    }
}
