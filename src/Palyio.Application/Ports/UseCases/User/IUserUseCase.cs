using Palyio.Application.UseCases.Boundaries.Input;
using Palyio.Domain;
using Palyio.Domain.Entities;

namespace Palyio.Application.Ports.UseCases
{
    public interface IUserUseCase
    {
        Task<Result<User>> CreateUser(CreateUserInput user);
    }
}