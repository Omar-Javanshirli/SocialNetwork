using AutoMapper;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Request;
using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Handlers.QueryHandlers
{
    public class GetAllCommentPostHandler : IRequestHandler<GetAllCommentPostRequest, Response<IEnumerable<GetAllCommentPostResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCommentPostHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllCommentPostResponse>>> Handle(GetAllCommentPostRequest request, CancellationToken cancellationToken)
        {
            var comments = await _unitOfWork.commentRepository.GetAllComment(request.PostId);
            var response = _mapper.Map<IEnumerable<GetAllCommentPostResponse>>(comments);
            return Response<IEnumerable<GetAllCommentPostResponse>>.Success(response, 200);
        }

    }
}
