using Palyio.Domain.Entities;

namespace Palyio.Application.Ports.Repositories;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(Guid id);
    Task<IEnumerable<Account>> GetByUserIdAsync(Guid userId);
    Task InsertAsync(Account account);
    Task UpdateAsync(Account account);
    Task DeleteAsync(Guid id);
}
