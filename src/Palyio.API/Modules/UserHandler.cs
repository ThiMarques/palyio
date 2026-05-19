using Microsoft.AspNetCore.Mvc;
using Palyio.Application.Ports.UseCases;
using Palyio.Application.UseCases;
using Palyio.Application.UseCases.Boundaries.Input;

namespace Palyio.API.Modules
{
    public static class UserHandler
    {
        public static async Task CreateUser(HttpContext context,
                                            [FromBody] CreateUserInput input,
                                            [FromServices] IUserUseCase userUseCase,
                                            CancellationToken cancellationToken = default)
        {
            var result = await userUseCase.CreateUser(input);

            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task GetAllUsers(HttpContext context,
                                             [FromServices] IUserUseCase userUseCase,
                                             CancellationToken cancellationToken = default)
        {
            var result = await userUseCase.GetAllUsers();
            
            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task GetUserById(HttpContext context,
                                             [FromServices] IUserUseCase userUseCase,
                                             [FromRoute] Guid id,
                                             CancellationToken cancellationToken = default)
        {
            var result = await userUseCase.GetAllUsers();
            
            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task UpdateUser(HttpContext context,
                                            [FromServices] IUserUseCase userUseCase,
                                            [FromRoute] Guid id,
                                            [FromBody] UpdateUserInput input,
                                            CancellationToken cancellationToken = default)
        {
            var result = await userUseCase.UpdateUser(id, input);
            
            if (!result.Success)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.ErrorMessage, cancellationToken: cancellationToken);
            }

            context.Response.StatusCode = StatusCodes.Status200OK;
            await context.Response.WriteAsJsonAsync(result.Value, cancellationToken: cancellationToken);
        }

        public static async Task DeleteUser(HttpContext context,
                                            [FromServices] IUserUseCase userUseCase,
                                            [FromRoute] Guid id,
                                            CancellationToken cancellationToken = default)
        {
            var result = await userUseCase.DeleteUser(id);
            
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