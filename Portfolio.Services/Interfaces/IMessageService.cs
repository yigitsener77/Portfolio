using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Entities.Models;

namespace Portfolio.Services.Interfaces
{
    public interface IMessageService
    {
        Task<Message> GetByIdAsync(int id);
        Task<IEnumerable<Message>> GetAllAsync();
        Task AddAsync(Message message);
        Task UpdateAsync(Message message);
        Task DeleteAsync(int id);
    }
}
