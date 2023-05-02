using MediatR;
using StacPointTask.BL.Models;

namespace StecPointTask.MediatrCommands
{
    public class CreateUserCommand: IRequest<int>
    {
        public UserModel User { get; set; }
    }
}