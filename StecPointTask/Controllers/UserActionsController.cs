using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Serilog;
using StacPointTask.BL.Interfaces;
using StacPointTask.BL.Models;
using StecPointTask.MediatrCommands;
using StecPointTask.MQ.MQInterfaces;

namespace StecPointTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IProducerInterface _mqProducer;
        private readonly IMediator _mediatR;
        

        public UserActionsController(IUserService userService, 
                                    IProducerInterface producerInterface, 
                                    IMediator mediatR)
        {
            _userService = userService;
            _mqProducer = producerInterface;
            _mediatR = mediatR;
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            try
            {
                await _mediatR.Send(new CreateUserCommand
                {
                    User = userModel
                });
                Log.Information($"Информация о пользователе {userModel.FirstName} {userModel.LastName} сохранена в базе данных");
                await _mqProducer.Publish(userModel);
                Log.Information($"Информация о пользователе {userModel.FirstName} {userModel.LastName} успешно отправлена в очередь сообщений");

            }
            catch (WebException e)
            {
                Log.Fatal("Произошла WEB ошибка", e.Message);
            }
            catch (Exception e)
            {
                Log.Fatal("Произошла ошибка", e.Message);
            }

            return Ok();
        }

        [HttpPost]
        [Route("getUsersByOrganization")]
        public async Task<IActionResult> GetUsersByOrganization()
        {
            try
            {
                var dict = await _userService.GetUsersByOrganization();
                return Ok(dict);
            }
            catch (WebException e)
            {
                Log.Fatal($"Произошла WEB ошибка: {e.Message}");
            }
            catch (Exception e)
            {
                Log.Fatal($"Произошла ошибка: {e.Message}");
            }

            return Ok(StatusCode(204));
        }
    }
}
