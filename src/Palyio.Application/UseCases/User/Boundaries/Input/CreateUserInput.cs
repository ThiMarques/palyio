using Palyio.Domain.Enum;

namespace Palyio.Application.UseCases.Boundaries.Input
{
    public class CreateUserInput
    {
        public required string Name { get; set; }
        public required DateTime BirthDate { get; set; }
        public required EGender Gender { get; set; }
    }
}