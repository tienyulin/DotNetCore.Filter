using Microsoft.AspNetCore.Builder;
using DotNetCore.Filter.Common.Handlers;

namespace DotNetCore.Filter.Common.Extensions
{
    /// <summary>
    /// Class MiddlewareExtensions
    /// </summary>
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Uses the message handler.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseMessageHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MessageHandler>();
        }
    }
}