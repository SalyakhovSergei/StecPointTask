using System.Threading.Tasks;
using MassTransit;
using Serilog;
using StacPointTask.BL.Models;
using StacPointTask.BL.RabbitMQ.Entites;
using StacPointTask.BL.RabbitMQ.Interfaces;

namespace StacPointTask.BL.RabbitMQ.Services
{
    public class RabbitMqService: IRabbitMQInterface
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMqService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Publish(UserModel userModel)
        {
            Log.Information($"Информация о пользователе {userModel.FirstName} {userModel.LastName} отправлена в очередь сообщений");
            await _publishEndpoint.Publish<UserCreated>(userModel);
        }
    }
}