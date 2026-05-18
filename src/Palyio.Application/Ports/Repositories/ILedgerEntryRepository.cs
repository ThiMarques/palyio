using Palyio.Domain.Entities;

namespace Palyio.Application.Ports.Repositories;

public interface ILedgerEntryRepository
{
    Task<IEnumerable<LedgerEntry>> GetByAccountIdAsync(Guid accountId);
    Task<IEnumerable<LedgerEntry>> GetByTransactionIdAsync(Guid transactionId);
    Task InsertAsync(LedgerEntry entry);
}
