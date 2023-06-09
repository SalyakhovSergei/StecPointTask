using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit.Initializers;
using Serilog;
using StacPointTask.BL.Interfaces;
using StacPointTask.BL.Models;
using StacPointTask.BL.RabbitMQ.Interfaces;
using StecPointTask.Data.DTO;
using StecPointTask.Data.Interfaces;

namespace StacPointTask.BL.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRabbitMQInterface _mqRabbitMq;

        public UserService(IUserRepository userRepository, 
                            IMapper mapper, 
                            IRabbitMQInterface mqRabbitMq)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mqRabbitMq = mqRabbitMq;
        }

        public async Task Create(UserModel user)
        {
            var model = _mapper.Map<UserDto>(user);

            Log.Information($"Информация о пользователе {user.FirstName} {user.LastName} отправлена в базу данных");

            await _mqRabbitMq.Publish(user);
            Log.Information($"Информация о пользователе {user.FirstName} {user.LastName} успешно отправлена в очередь сообщений");

            await _userRepository.Create(model);
        }

        public async Task<Dictionary<string, List<UserModel>>> GetUsersByOrganization()
        {
            Log.Information("Получен запрос на поиск клиентов по организациям");

            var users = await _userRepository.GetUsers();

            var usersByOrganization = users.GroupBy(r => r.Organization.Name).Select(e=> new 
            {
                Organization = e.Key,
                Users = users
            }).ToDictionary(r=>r.Organization, w=>w.Users.Select(e=> _mapper.Map<UserModel>(e)).ToList());

            return usersByOrganization;
        }
    }
}