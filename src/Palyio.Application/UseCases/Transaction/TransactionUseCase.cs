using Palyio.Application.Ports.Repositories;
using Palyio.Application.Ports.UseCases.Transaction;
using Palyio.Application.UseCases.Transaction.Boundaries.Input;
using Palyio.Domain;
using Palyio.Domain.Entities;
using Palyio.Domain.Enum;

namespace Palyio.Application.UseCases;

public class TransactionUseCase(
    ITransactionRepository transactionRepository,
    ILedgerEntryRepository ledgerEntryRepository,
    IAccountRepository accountRepository) : ITransactionUseCase
{
    public async Task<Result<Domain.Entities.Transaction>> CreateTransaction(CreateTransactionInput input)
    {
        if (input.Amount <= 0)
            return ConstantMessages.InvalidTransactionAmount;

        var transaction = new Domain.Entities.Transaction
        {
            FromAccountId = input.FromAccountId ?? Guid.Empty,
            ToAccountId = input.ToAccountId ?? Guid.Empty,
            Amount = input.Amount,
            TransactionType = input.TransactionType
        };

        switch (input.TransactionType)
        {
            case ETransactionType.TRANSFER:
                if (input.FromAccountId == null || input.ToAccountId == null)
                    return ConstantMessages.InvalidTransactionAccounts;

                if (await accountRepository.GetByIdAsync(input.FromAccountId.Value) == null)
                    return ConstantMessages.AccountNotFound;

                if (await accountRepository.GetByIdAsync(input.ToAccountId.Value) == null)
                    return ConstantMessages.AccountNotFound;

                await transactionRepository.InsertAsync(transaction);
                await ledgerEntryRepository.InsertAsync(new LedgerEntry
                {
                    AccountId = input.FromAccountId.Value,
                    TransactionId = transaction.Id,
                    Amount = input.Amount,
                    EntryType = EEntryType.DEBIT
                });
                await ledgerEntryRepository.InsertAsync(new LedgerEntry
                {
                    AccountId = input.ToAccountId.Value,
                    TransactionId = transaction.Id,
                    Amount = input.Amount,
                    EntryType = EEntryType.CREDIT
                });
                break;

            case ETransactionType.DEPOSIT:
                if (input.ToAccountId == null)
                    return ConstantMessages.InvalidTransactionAccounts;

                if (await accountRepository.GetByIdAsync(input.ToAccountId.Value) == null)
                    return ConstantMessages.AccountNotFound;

                await transactionRepository.InsertAsync(transaction);
                await ledgerEntryRepository.InsertAsync(new LedgerEntry
                {
                    AccountId = input.ToAccountId.Value,
                    TransactionId = transaction.Id,
                    Amount = input.Amount,
                    EntryType = EEntryType.CREDIT
                });
                break;

            case ETransactionType.WITHDRAW:
                if (input.FromAccountId == null)
                    return ConstantMessages.InvalidTransactionAccounts;

                if (await accountRepository.GetByIdAsync(input.FromAccountId.Value) == null)
                    return ConstantMessages.AccountNotFound;

                await transactionRepository.InsertAsync(transaction);
                await ledgerEntryRepository.InsertAsync(new LedgerEntry
                {
                    AccountId = input.FromAccountId.Value,
                    TransactionId = transaction.Id,
                    Amount = input.Amount,
                    EntryType = EEntryType.DEBIT
                });
                break;
        }

        return transaction;
    }

    public async Task<Result<Domain.Entities.Transaction>> GetTransactionById(Guid id)
    {
        var transaction = await transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            return ConstantMessages.TransactionNotFound;
        return transaction;
    }

    public async Task<Result<List<Domain.Entities.Transaction>>> GetTransactionsByAccountId(Guid accountId)
    {
        var transactions = await transactionRepository.GetByAccountIdAsync(accountId);
        if (!transactions.Any())
            return ConstantMessages.TransactionsNotFound;
        return transactions.ToList();
    }
}
