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
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Project>> GetProjectsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }
    }
}
