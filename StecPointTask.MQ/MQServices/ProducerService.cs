using System.Threading.Tasks;
using MassTransit;
using Serilog;
using StacPointTask.BL.Models;
using StecPointTask.MQ.Enities;
using StecPointTask.MQ.MQInterfaces;

namespace StecPointTask.MQ.MQServices
{
    public class ProducerService: IProducerInterface
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ProducerService(IPublishEndpoint publishEndpoint)
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