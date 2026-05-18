using Palyio.Domain.Enum;

namespace Palyio.Domain.Entities
{
    public record class Transaction : Entity
    {
        public required Guid FromAccountId { get; set; }
        public required Guid ToAccountId { get; set; }
        public required long Amount { get; set; }
        public required ETransactionType TransactionType { get; set; }
    }
}