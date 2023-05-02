using StecPointTask.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StecPointTask.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Create(UserDto user);
        Task<List<UserDto>> GetUsers();
    }
}