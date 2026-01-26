using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Eszi.Beadando.Server.Middlewares
{

    public class AuthorizationHeaderSetterMiddleware(RequestDelegate next)
    {
        //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/primary-constructors
        public async Task Invoke(HttpContext context)
        {
            context.Request.Cookies.TryGetValue("accessToken", out string? accessToken);

            if(string.Compare(context.Request.Path, "/auth/login", System.StringComparison.OrdinalIgnoreCase) >= 0 && !string.IsNullOrEmpty(accessToken))
            {
                context.Request.Headers.Authorization = $"Bearer {accessToken}";
            }

            await next(context);
        }
    }
}
