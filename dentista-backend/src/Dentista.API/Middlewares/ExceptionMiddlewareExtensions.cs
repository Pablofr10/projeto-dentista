using Microsoft.AspNetCore.Builder;

namespace Dentista.API.Middlewares
{
    public static  class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
