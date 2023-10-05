using B._SocialNetwork.Services.Graph.Core.Dtos.Users;
using B._SocialNetwork.Services.Graph.Core.UnitOfWorks;
using MassTransit;
using SocialNetwork.SharedForIdentityServer.Messages;

namespace D._SocialNetwork.Services.Graph.Services.Consumers
{
    public class CreateUserMessageEventConsumer : IConsumer<CreateUserMessageEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserMessageEventConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Consume(ConsumeContext<CreateUserMessageEvent> context)
        {
            User_CreateDto user = new()
            {
                Username = context.Message.Username,
                Id = context.Message.UserId,
                Email = context.Message.Email,
            };

            await _unitOfWork.GetGenericRepository<User_CreateDto>().AddAsync(user);
        }
    }
}
