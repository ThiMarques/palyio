using Palyio.Domain.Enum;

namespace Palyio.Domain.Entities
{
    public record class LedgerEntry : Entity
    {
        public Guid AccountId { get; set; }
        public Guid TransactionId { get; set; }
        public long Amount { get; set; }
        public EEntryType EntryType { get; set; }
    }
}