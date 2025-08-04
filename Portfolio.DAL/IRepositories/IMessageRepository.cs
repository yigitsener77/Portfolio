using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Entities.Models;

namespace Portfolio.DAL.IRepositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessagesByEmailAsync(string email);
    }
}
