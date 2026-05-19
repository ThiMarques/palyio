using Palyio.Application.UseCases.Boundaries.Input;
using Palyio.Domain;
using Palyio.Domain.Entities;

namespace Palyio.Application.Ports.UseCases
{
    public interface IUserUseCase
    {
        Task<Result<User>> CreateUser(CreateUserInput user);
        Task<Result<List<User>>> GetAllUsers();
        Task<Result<User>> GetUserById(Guid id);
        Task<Result<User>> UpdateUser(Guid id, UpdateUserInput input);
        Task<Result<bool>> DeleteUser(Guid id);
    }
}