using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Request;
using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Response;
using MediatR;

namespace D._SocialNetwork.Services.Graph.Services.CQRS.User.Handlers.QueryHandlers
{
    public class GetAllUserPostsQueryHandler : IRequestHandler<GetAllUserPostsQueryRequest, IEnumerable<GetAllUserPostsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUserPostsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetAllUserPostsQueryResponse>> Handle(GetAllUserPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var userPots=await _unitOfWork.userRepository.GetAllUserPostsAsync(request.UserId);

            throw new NotImplementedException();
        }
    }
}
