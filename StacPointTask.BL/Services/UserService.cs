using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit.Initializers;
using Serilog;
using StacPointTask.BL.Interfaces;
using StacPointTask.BL.Models;
using StecPointTask.Data.DTO;
using StecPointTask.Data.Interfaces;

namespace StacPointTask.BL.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, 
                            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(UserModel user)
        {
            var model = _mapper.Map<UserDto>(user);

            Log.Information($"Информация о пользователе {user.FirstName} {user.LastName} отправлена в базу данных");

            return await _userRepository.Create(model);
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