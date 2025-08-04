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
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Message>> GetMessagesByEmailAsync(string email)
        {
            return await _dbSet
             .Where(m => m.Email == email)
             .ToListAsync();
        }
    }
}
