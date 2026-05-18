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

        return builder;
    }
}