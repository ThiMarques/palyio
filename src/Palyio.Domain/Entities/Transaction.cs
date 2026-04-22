using Palyio.Domain.Enum;

namespace Palyio.Domain.Entities
{
    public record class Transaction : Entity
    {
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public long Amount { get; set; }
        public ETransactionType TransactionType { get; set; }
    }
}