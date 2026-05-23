using Palyio.Application.UseCases.Transaction.Boundaries.Input;
using Palyio.Domain;

namespace Palyio.Application.Ports.UseCases.Transaction;

public interface ITransactionUseCase
{
    Task<Result<Domain.Entities.Transaction>> CreateTransaction(CreateTransactionInput input);
    Task<Result<Domain.Entities.Transaction>> GetTransactionById(Guid id);
    Task<Result<List<Domain.Entities.Transaction>>> GetTransactionsByAccountId(Guid accountId);
}
