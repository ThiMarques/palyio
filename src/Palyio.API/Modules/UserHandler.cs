using Microsoft.AspNetCore.Mvc;
using Palyio.Application.Ports.UseCases;
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
        }
    }
}