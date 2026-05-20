using Palyio.Domain.Enum;

namespace Palyio.Application.UseCases.Boundaries.Input
{
    public class UpdateAccountInput
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
    }
}