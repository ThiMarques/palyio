using Palyio.Domain.Entities;

namespace Palyio.Application.Ports.Repositories;

public interface ITransactionRepository
{
    Task<Transaction?> GetByIdAsync(Guid id);
    Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId);
    Task InsertAsync(Transaction transaction);
}
