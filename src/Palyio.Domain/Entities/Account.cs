using Palyio.Domain.Enum;

namespace Palyio.Domain.Entities
{
    public record class Account : Entity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Color { get; set; }
        public required EAccountType AccountType { get; set; }
        public required Guid UserId { get; set; }
    }
}