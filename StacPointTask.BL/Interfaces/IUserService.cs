using System.Collections.Generic;
using System.Threading.Tasks;
using StacPointTask.BL.Models;
using StecPointTask.Data.DTO;

namespace StacPointTask.BL.Interfaces
{
    public interface IUserService
    {
        Task Create(UserModel user);
        Task <Dictionary<string, List<UserModel>>> GetUsersByOrganization();
    }
}