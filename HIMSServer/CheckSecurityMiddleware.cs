using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace HIMSServer
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CheckSecurityMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckSecurityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //write security code here
            Console.WriteLine("checking request");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CheckSecurityMiddlewareExtensions
    {
        public static IApplicationBuilder UseCheckSecurityMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckSecurityMiddleware>();
        }
    }
}
