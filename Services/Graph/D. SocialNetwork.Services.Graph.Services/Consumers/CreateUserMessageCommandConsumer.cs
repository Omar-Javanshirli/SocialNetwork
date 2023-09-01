using B._SocialNetwork.Services.Graph.Core.Entities;
using MassTransit;
using SocialNetwork.Shared.Messages;

namespace D._SocialNetwork.Services.Graph.Services.Consumers
{
    public class CreateUserMessageCommandConsumer : IConsumer<CreateUserMessageCommand>
    {
        public Task Consume(ConsumeContext<CreateUserMessageCommand> context)
        {
            User user = new()
            {
                Username = context.Message.Username,
                Id = context.Message.UserId,
                Email = context.Message.Email,
            };
            
            // databaseye elave olunmalidi deyisikler
            return Task.CompletedTask;
        }
    }
}
