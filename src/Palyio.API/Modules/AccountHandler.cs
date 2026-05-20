using Microsoft.AspNetCore.Mvc;
using Palyio.Application.Ports.UseCases;
using Palyio.Application.UseCases.Boundaries.Input;

namespace Palyio.API.Modules
{
    public static class AccountHandler
    {
        public static async Task CreateAccount(HttpContext context,
                                            [FromBody] CreateAccountInput input,
                                            [FromServices] IAccountUseCase accountUseCase,
                                            CancellationToken cancellationToken = default)
        {
            var result = await accountUseCase.CreateAccount(input);

            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task GetAllAccounts(HttpContext context,
                                             [FromServices] IAccountUseCase accountUseCase,
                                             CancellationToken cancellationToken = default)
        {
            var result = await accountUseCase.GetAllAccounts();
            
            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task GetAccountsByUserId(HttpContext context,
                                                    [FromServices] IAccountUseCase accountUseCase,
                                                    [FromRoute] Guid userId,
                                                    CancellationToken cancellationToken = default)
        {
            var result = await accountUseCase.GetAccountByUserId(userId);
            
            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task GetAccountById(HttpContext context,
                                             [FromServices] IAccountUseCase accountUseCase,
                                             [FromRoute] Guid id,
                                             CancellationToken cancellationToken = default)
        {
            var result = await accountUseCase.GetAccountById(id);
            
            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task UpdateAccount(HttpContext context,
                                            [FromServices] IAccountUseCase accountUseCase,
                                            [FromRoute] Guid id,
                                            [FromBody] UpdateAccountInput input,
                                            CancellationToken cancellationToken = default)
        {
            var result = await accountUseCase.UpdateAccount(id, input);
            
            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task DeleteAccount(HttpContext context,
                                            [FromServices] IAccountUseCase accountUseCase,
                                            [FromRoute] Guid id,
                                            CancellationToken cancellationToken = default)
        {
            var result = await accountUseCase.DeleteAccount(id);
            
            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }
    }
}