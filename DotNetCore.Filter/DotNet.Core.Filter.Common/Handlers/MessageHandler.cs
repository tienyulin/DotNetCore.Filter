using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace DotNetCore.Filter.Common.Handlers
{
    /// <summary>
    /// Class MessageHandler
    /// </summary>
    public class MessageHandler
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageHandler"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public MessageHandler(RequestDelegate next)
        {
            this._next = next;
        }

        /// <summary>
        /// Invokes the asynchronous.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task InvokeAsync(HttpContext context)
        {
            // Request
            var response = context.Response.Body;

            using (var memoryStream = new MemoryStream())
            {
                context.Response.Body = memoryStream;

                await this._next(context);

                context.Response.Body.Position = 0;

                await memoryStream.CopyToAsync(response);
            }

            // Response
        }
    }
}