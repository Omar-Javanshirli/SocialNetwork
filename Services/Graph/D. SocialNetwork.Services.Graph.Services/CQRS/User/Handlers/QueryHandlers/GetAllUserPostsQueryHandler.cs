using AutoMapper;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Request;
using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Response;
using MediatR;
using SocialNetwork.Shared.Dtos;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.User.Handlers.QueryHandlers
{
    public class GetAllUserPostsQueryHandler : IRequestHandler<GetAllUserPostsQueryRequest, Response<IEnumerable<GetAllUserPostsQueryResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUserPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllUserPostsQueryResponse>>> Handle(GetAllUserPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var userPots = await _unitOfWork.userRepository.GetAllUserPostsAsync(request.UserId);
            var userResponse = _mapper.Map<IEnumerable<GetAllUserPostsQueryResponse>>(userPots);
            return Response<IEnumerable<GetAllUserPostsQueryResponse>>.Success(userResponse, 200);
        }
    }
}