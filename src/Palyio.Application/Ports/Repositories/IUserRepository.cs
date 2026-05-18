using Palyio.Domain.Entities;

namespace Palyio.Application.Ports.Repositories;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    Task InsertAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
