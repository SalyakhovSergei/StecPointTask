using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StecPointTask.Data.DTO;
using StecPointTask.Data.Interfaces;

namespace StecPointTask.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<int> Create(UserDto user)
        {
            var entry = _context.Entry(user);
            if (entry.State == EntityState.Detached)
            {
                await _context.User.AddAsync(user);
            }
            
            return await _context.SaveChangesAsync();
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var users = await _context.User.Include(nameof(_context.Organization)).AsNoTracking().ToListAsync();
            
            return users;
        }
    }
}