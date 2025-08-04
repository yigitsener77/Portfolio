using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.DAL.Data;
using Portfolio.DAL.IRepositories;
using Portfolio.Entities.Models;

namespace Portfolio.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User> GetUserWithProjectsAsync(int userId)
        {
            return await _dbSet
                .Include(u => u.Projects)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
