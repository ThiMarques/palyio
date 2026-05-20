using Palyio.Application.UseCases.Boundaries.Input;
using Palyio.Domain;
using Palyio.Domain.Entities;

namespace Palyio.Application.Ports.UseCases
{
    public interface IAccountUseCase
    {
        Task<Result<Account>> CreateAccount(CreateAccountInput input);
        Task<Result<List<Account>>> GetAllAccounts();
        Task<Result<List<Account>>> GetAccountByUserId(Guid userId);
        Task<Result<Account>> GetAccountById(Guid accountId);
        Task<Result<Account>> UpdateAccount(Guid id, UpdateAccountInput input);
        Task<Result<bool>> DeleteAccount(Guid id);
    }
}