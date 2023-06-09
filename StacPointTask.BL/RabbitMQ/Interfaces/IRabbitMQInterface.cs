using System.Threading.Tasks;
using StacPointTask.BL.Models;

namespace StacPointTask.BL.RabbitMQ.Interfaces
{
    public interface IRabbitMQInterface
    {
        Task Publish(UserModel userModel);
    }
}