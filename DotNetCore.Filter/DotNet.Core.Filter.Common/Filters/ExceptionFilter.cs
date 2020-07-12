using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Threading.Tasks;
using DotNetCore.Filter.Common.Infrastructure.Models;

namespace DotNetCore.Filter.Common.Filters
{
    /// <summary>
    /// Class ExceptionFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncExceptionFilter" />
    public class ExceptionFilter : IAsyncExceptionFilter
    {
        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
        /// <returns>
        /// A <see cref="T:System.Threading.Tasks.Task" /> that on completion indicates the filter has executed.
        /// </returns>
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var response = new FailResultViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Method = $"{context.HttpContext.Request.Path}.{context.HttpContext.Request.Method}",
                Status = "Error",
                Version = "1.0",
                Error = new FailInformation
                {
                    Domain = "ProjectName",
                    ErrorCode = 40000,
                    Message = context.Exception.Message,
                    Description = context.Exception.ToString()
                }
            };

            context.Result = new ObjectResult(response)
            {
                // 500
                StatusCode = (int)HttpStatusCode.InternalServerError
            };

            // Exceptinon Filter只在ExceptionHandled=false時觸發
            // 所以處理完Exception要標記true表示已處理
            context.ExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}