

using Palyio.Application.Ports.Repositories;
using Palyio.Application.Ports.UseCases;
using Palyio.Application.UseCases.Boundaries.Input;
using Palyio.Domain;
using Palyio.Domain.Entities;

namespace Palyio.Application.UseCases
{
    public class UserUseCase(IUserRepository userRepository) : IUserUseCase
    {
        public async Task<Result<User>> CreateUser(CreateUserInput input)
        {
            if (string.IsNullOrEmpty(input.Name))
                return ConstantMessages.InvalidName;

            var newUser = new User(
                name: input.Name,
                birthDate: input.BirthDate,
                gender: input.Gender
            );
            await userRepository.InsertAsync(newUser);

            return newUser;
        }
    }
}