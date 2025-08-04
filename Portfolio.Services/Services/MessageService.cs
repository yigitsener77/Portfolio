using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.DAL.IRepositories;
using Portfolio.Entities.Models;
using Portfolio.Services.Interfaces;

namespace Portfolio.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task AddAsync(Message message)
        {
            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var message = await _messageRepository.GetByIdAsync(id);
            if (message != null)
            {
                _messageRepository.Delete(message);
                await _messageRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Message>> GetAllAsync() => await _messageRepository.GetAllAsync();

        public async Task<Message> GetByIdAsync(int id) => await _messageRepository.GetByIdAsync(id);

        public async Task UpdateAsync(Message message)
        {
            _messageRepository.Update(message);
            await _messageRepository.SaveChangesAsync();
        }
    }
}
