using Microsoft.AspNetCore.Mvc;
using Palyio.Application.Ports.UseCases.Transaction;
using Palyio.Application.UseCases.Transaction.Boundaries.Input;

namespace Palyio.API.Modules;

public static class TransactionHandler
{
    public static async Task CreateTransaction(HttpContext context,
                                               [FromBody] CreateTransactionInput input,
                                               [FromServices] ITransactionUseCase transactionUseCase,
                                               CancellationToken cancellationToken = default)
    {
        var result = await transactionUseCase.CreateTransaction(input);

        if (!result.Success)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            return;
        }

        context.Response.StatusCode = StatusCodes.Status201Created;
        await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
    }

    public static async Task GetTransactionById(HttpContext context,
                                                [FromServices] ITransactionUseCase transactionUseCase,
                                                [FromRoute] Guid id,
                                                CancellationToken cancellationToken = default)
    {
        var result = await transactionUseCase.GetTransactionById(id);

        if (!result.Success)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            return;
        }

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
    }

    public static async Task GetTransactionsByAccountId(HttpContext context,
                                                        [FromServices] ITransactionUseCase transactionUseCase,
                                                        [FromRoute] Guid accountId,
                                                        CancellationToken cancellationToken = default)
    {
        var result = await transactionUseCase.GetTransactionsByAccountId(accountId);

        if (!result.Success)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            return;
        }

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
    }
}
