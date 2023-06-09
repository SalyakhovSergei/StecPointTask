using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Serilog;
using StacPointTask.BL.Interfaces;
using StacPointTask.BL.Models;

namespace StecPointTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionsController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserActionsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserModel userModel)
        {
            try
            {
                await _userService.Create(userModel);
                Log.Information($"Информация о пользователе {userModel.FirstName} {userModel.LastName} сохранена в базе данных");
            }
            catch (WebException e)
            {
                Log.Error("Произошла WEB ошибка: {0}", e.Message);
                throw;
            }
            catch (Exception e)
            {
                Log.Error("Произошла ошибка: {0}", e.Message);
                throw;
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
                Log.Error("Произошла WEB ошибка: {0}", e.Message);
                throw;
            }
            catch (Exception e)
            {
                Log.Error("Произошла ошибка: {0}", e.Message);
                throw;
            }

            return Ok();
        }
    }
}
