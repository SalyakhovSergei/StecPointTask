using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StacPointTask.BL.Interfaces;
using StacPointTask.BL.Models;

namespace StecPointTask.MediatrCommands
{
    public class CreateUserCommandHandler: IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           return await _userService.Create(request.User);
        }
    }
}