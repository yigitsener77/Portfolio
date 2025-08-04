using Portfolio.Entities.Models;

namespace Portfolio.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<User> GetUserWithProjectsAsync(int id);
    }
}
