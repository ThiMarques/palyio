using Palyio.Application.Ports.Repositories;
using Palyio.Application.Ports.UseCases;
using Palyio.Application.UseCases.Boundaries.Input;
using Palyio.Domain;
using Palyio.Domain.Entities;

namespace Palyio.Application.UseCases
{
    public class AccountUseCase(IAccountRepository accountRepository,
                                IUserRepository userRepository) : IAccountUseCase
    {
        public async Task<Result<Account>> CreateAccount(CreateAccountInput input)
        {
            if (string.IsNullOrEmpty(input.Name))
                return ConstantMessages.InvalidAccountName;

            var user = await userRepository.GetByIdAsync(input.UserId);

            if (user == null)
                return ConstantMessages.UserNotFound;

            var newAccount = new Account(
                name: input.Name,
                description: input.Description,
                color: input.Color,
                accountType: input.AccountType,
                userId: input.UserId
            );

            await accountRepository.InsertAsync(newAccount);

            return newAccount;
        }

        public async Task<Result<List<Account>>> GetAllAccounts()
        {
            var accounts = await accountRepository.GetAllAccountsAsync();

            if (!accounts.Any())
                return ConstantMessages.AccountsNotFound;
            
            return accounts.ToList();
        }

        public async Task<Result<List<Account>>> GetAccountByUserId(Guid userId)
        {
            var accounts = await accountRepository.GetByUserIdAsync(userId);
            
            if (accounts == null || !accounts.Any())
                return ConstantMessages.AccountsNotFound;

            return accounts.ToList();
        }

        public async Task<Result<Account>> GetAccountById(Guid accountId)
        {
            var account = await accountRepository.GetByIdAsync(accountId);
            
            if (account == null)
                return ConstantMessages.AccountNotFound;

            return account;
        }

        public async Task<Result<Account>> UpdateAccount(Guid id, UpdateAccountInput input)
        {
            var account = await accountRepository.GetByIdAsync(id);

            if (account == null)
                return ConstantMessages.AccountNotFound;

            if (input.Name != null)
            {
                account.Name = input.Name;
            }

            if (input.Description != null)
            {
                account.Description = input.Description;
            }

            if (input.Color != null)
            {
                account.Color = input.Color;
            }

            await accountRepository.UpdateAsync(account);

            return account;
        }

        public async Task<Result<bool>> DeleteAccount(Guid id)
        {
            var account = await accountRepository.GetByIdAsync(id);

            if (account == null)
                return ConstantMessages.AccountNotFound;

            await accountRepository.DeleteAsync(id);

            return true;
        }
    }
}