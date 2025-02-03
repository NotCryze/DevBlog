using DevBlog.Web.DTO;
using DevBlog.Web.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace DevBlog.Web.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next, IMemoryCache cache)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            httpContext.Items["User"] = httpContext.Session.GetAccount();

            PathString path = httpContext.Request.Path;

            if (path.HasValue)
            {
                if (httpContext.Items["User"] == null)
                {
                    if (!path.Value.ToLower().Contains("/register") && !path.Value.ToLower().Contains("/login"))
                    {
                        httpContext.Response.Redirect("/Login");
                        return;
                    }
                }
            }
            await _next(httpContext);
        }
    }

    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
