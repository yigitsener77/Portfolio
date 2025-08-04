using Portfolio.Entities.Models;

namespace Portfolio.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Project> GetByIdAsync(int id);
        Task<IEnumerable<Project>> GetAllAsync();
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);
        Task<IEnumerable<Project>> GetProjectsByUserIdAsync(int userId);

    }
}
