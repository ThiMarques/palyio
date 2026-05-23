using Palyio.Domain;

namespace Palyio.Application.Ports.UseCases.LedgerEntry;

public interface ILedgerEntryUseCase
{
    Task<Result<List<Domain.Entities.LedgerEntry>>> GetByAccountId(Guid accountId);
    Task<Result<List<Domain.Entities.LedgerEntry>>> GetByTransactionId(Guid transactionId);
    Task<Result<long>> GetBalanceByAccountId(Guid accountId);
}
