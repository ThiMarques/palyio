using Palyio.Application.Ports.Repositories;
using Palyio.Application.Ports.UseCases.LedgerEntry;
using Palyio.Domain;
using Palyio.Domain.Enum;

namespace Palyio.Application.UseCases;

public class LedgerEntryUseCase(ILedgerEntryRepository ledgerEntryRepository) : ILedgerEntryUseCase
{
    public async Task<Result<List<Domain.Entities.LedgerEntry>>> GetByAccountId(Guid accountId)
    {
        var entries = await ledgerEntryRepository.GetByAccountIdAsync(accountId);
        if (!entries.Any())
            return ConstantMessages.LedgerEntriesNotFound;
        return entries.ToList();
    }

    public async Task<Result<List<Domain.Entities.LedgerEntry>>> GetByTransactionId(Guid transactionId)
    {
        var entries = await ledgerEntryRepository.GetByTransactionIdAsync(transactionId);
        if (!entries.Any())
            return ConstantMessages.LedgerEntriesNotFound;
        return entries.ToList();
    }

    public async Task<Result<long>> GetBalanceByAccountId(Guid accountId)
    {
        var entries = await ledgerEntryRepository.GetByAccountIdAsync(accountId);
        var balance = entries.Sum(e => e.EntryType == EEntryType.CREDIT ? e.Amount : -e.Amount);
        return balance;
    }
}
