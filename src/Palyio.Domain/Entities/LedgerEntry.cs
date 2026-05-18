using Palyio.Domain.Enum;

namespace Palyio.Domain.Entities
{
    public record class LedgerEntry : Entity
    {
        public required Guid AccountId { get; set; }
        public required Guid TransactionId { get; set; }
        public required long Amount { get; set; }
        public required EEntryType EntryType { get; set; }
    }
}