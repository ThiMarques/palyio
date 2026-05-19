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
        v1.MapPost("/user", UserHandler.CreateUser);
        v1.MapGet("/users", UserHandler.GetAllUsers);
        v1.MapGet("/user/{id}", UserHandler.GetUserById);
        v1.MapPut("/user/{id}", UserHandler.UpdateUser);
        v1.MapDelete("/user/{id}", UserHandler.DeleteUser);

        return builder;
    }
}