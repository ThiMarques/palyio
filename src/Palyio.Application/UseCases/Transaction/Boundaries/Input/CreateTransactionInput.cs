using Palyio.Domain.Enum;

namespace Palyio.Application.UseCases.Transaction.Boundaries.Input;

public class CreateTransactionInput
{
    public Guid? FromAccountId { get; set; }
    public Guid? ToAccountId { get; set; }
    public long Amount { get; set; }
    public ETransactionType TransactionType { get; set; }
}
