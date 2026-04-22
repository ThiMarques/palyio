using Palyio.Domain.Enum;

namespace Palyio.Domain.Entities
{
    public record class Account : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public EAccountType AccountType { get; set; }
        public Guid UserId { get; set; }
    }
}