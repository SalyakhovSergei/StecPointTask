using StacPointTask.BL.Models;
using System.Threading.Tasks;

namespace StecPointTask.MQ.MQInterfaces
{
    public interface IProducerInterface
    {
        Task Publish(UserModel userModel);
    }
}