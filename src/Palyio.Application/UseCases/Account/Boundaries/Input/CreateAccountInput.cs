using Palyio.Domain.Enum;

namespace Palyio.Application.UseCases.Boundaries.Input
{
    public class CreateAccountInput
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Color { get; set; }
        public required EAccountType AccountType { get; set; }
        public required Guid UserId { get; set; }
    }
}