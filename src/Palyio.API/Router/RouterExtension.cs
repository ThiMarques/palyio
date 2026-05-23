using Palyio.API.Modules;

namespace Palyio.API.Router;

public static class RouterExtensions
{
    public static WebApplication MapApiRoutes(this WebApplication builder)
    {
        return builder.MapRoutes();
    }

    private static WebApplication MapRoutes(this WebApplication builder)
    {
        var v1 = builder.MapGroup("/v1");
        // User Routes
        v1.MapPost("/user", UserHandler.CreateUser);
        v1.MapGet("/users", UserHandler.GetAllUsers);
        v1.MapGet("/user/{id}", UserHandler.GetUserById);
        v1.MapPut("/user/{id}", UserHandler.UpdateUser);
        v1.MapDelete("/user/{id}", UserHandler.DeleteUser);
        // Account Routes
        v1.MapPost("/account", AccountHandler.CreateAccount);
        v1.MapGet("/accounts", AccountHandler.GetAllAccounts);
        v1.MapGet("/accounts/user/{userId}", AccountHandler.GetAccountsByUserId);
        v1.MapGet("/account/{id}", AccountHandler.GetAccountById);
        v1.MapPut("/account/{id}", AccountHandler.UpdateAccount);
        v1.MapDelete("/account/{id}", AccountHandler.DeleteAccount);
        // Transaction Routes
        v1.MapPost("/transaction", TransactionHandler.CreateTransaction);
        v1.MapGet("/transaction/{id}", TransactionHandler.GetTransactionById);
        v1.MapGet("/transactions/account/{accountId}", TransactionHandler.GetTransactionsByAccountId);
        // LedgerEntry Routes (read-only)
        v1.MapGet("/ledger-entries/account/{accountId}/balance", LedgerEntryHandler.GetBalanceByAccountId);
        v1.MapGet("/ledger-entries/account/{accountId}", LedgerEntryHandler.GetLedgerEntriesByAccountId);
        v1.MapGet("/ledger-entries/transaction/{transactionId}", LedgerEntryHandler.GetLedgerEntriesByTransactionId);

        return builder;
    }
}