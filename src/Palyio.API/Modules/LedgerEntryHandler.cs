using Microsoft.AspNetCore.Mvc;
using Palyio.Application.Ports.UseCases.LedgerEntry;

namespace Palyio.API.Modules;

public static class LedgerEntryHandler
{
    public static async Task GetLedgerEntriesByAccountId(HttpContext context,
                                                         [FromServices] ILedgerEntryUseCase ledgerEntryUseCase,
                                                         [FromRoute] Guid accountId,
                                                         CancellationToken cancellationToken = default)
    {
        var result = await ledgerEntryUseCase.GetByAccountId(accountId);

        if (!result.Success)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            return;
        }

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
    }

    public static async Task GetBalanceByAccountId(HttpContext context,
                                                    [FromServices] ILedgerEntryUseCase ledgerEntryUseCase,
                                                    [FromRoute] Guid accountId,
                                                    CancellationToken cancellationToken = default)
    {
        var result = await ledgerEntryUseCase.GetBalanceByAccountId(accountId);

        if (!result.Success)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            return;
        }

        context.Response.StatusCode = StatusCodes.Status200OK;
        await context.Response.WriteAsJsonAsync(new { accountId, balance = result.Value }, cancellationToken: cancellationToken);
    }

    public static async Task GetLedgerEntriesByTransactionId(HttpContext context,
                                                              [FromServices] ILedgerEntryUseCase ledgerEntryUseCase,
                                                              [FromRoute] Guid transactionId,
                                                              CancellationToken cancellationToken = default)
    {
        var result = await ledgerEntryUseCase.GetByTransactionId(transactionId);

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
