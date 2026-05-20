

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

        public async Task<Result<List<User>>> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();

            if (!users.Any())
                return ConstantMessages.UsersNotFound;

            return users.ToList();
        }

        public async Task<Result<User>> GetUserById(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null)
                return ConstantMessages.UsersNotFound;

            return user;
        }

        public async Task<Result<User>> UpdateUser(Guid id, UpdateUserInput input)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null)
                return ConstantMessages.UserNotFound;

            if (input.Name != "")
            {
                user.Name = input.Name;
            }

            await userRepository.UpdateAsync(user);

            return user;
        }

        public async Task<Result<bool>> DeleteUser(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user == null)
                return ConstantMessages.UserNotFound;

            await userRepository.DeleteAsync(id);

            return true;
        }
    }
}