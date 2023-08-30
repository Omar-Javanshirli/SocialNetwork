using AutoMapper;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using D._SocialNetwork.Services.Graph.Services.CQRS.Post.Queries.Request;
using D._SocialNetwork.Services.Graph.Services.CQRS.Post.Queries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.Post.Handlers.QueryHandlers
{
    public class GetAllUsersPostLikeQueryHandler : IRequestHandler<GetAllUsersPostLikeQueryRequest, Response<IEnumerable<GetAllUsersPostLikeQueryResponse>>>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;

        public GetAllUsersPostLikeQueryHandler(IUnitOfWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllUsersPostLikeQueryResponse>>> Handle(GetAllUsersPostLikeQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _unitofWork.postRepository.GetPostLikesAsync(request.PostId);
            var response = _mapper.Map<IEnumerable<GetAllUsersPostLikeQueryResponse>>(users);
            return Response<IEnumerable<GetAllUsersPostLikeQueryResponse>>.Success(response, 200);
        }
    }
}
