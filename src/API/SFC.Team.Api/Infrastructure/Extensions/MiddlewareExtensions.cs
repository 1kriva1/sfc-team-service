using SFC.Team.Api.Infrastructure.Middlewares;

namespace SFC.Team.Api.Infrastructure.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}