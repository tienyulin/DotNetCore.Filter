using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DotNetCore.Filter.Common.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCore.Filter.Common.Filters
{
    /// <summary>
    /// Class ValidationActionFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter" />
    public class ValidationActionFilter : IAsyncActionFilter, IOrderedFilter
    {
        public int Order { get; set; } = 0;

        /// <summary>
        /// Called asynchronously before the action, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        /// <param name="next">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate" />. Invoked to execute the next action filter or the action itself.</param>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var parameter = context.ActionArguments.SingleOrDefault();
            if (parameter.Value is null)
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
                        Message = "參數驗證失敗",
                        Description = "傳入參數為null"
                    }
                };

                context.Result = new ObjectResult(response)
                {
                    // 400
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
            }
            else
            {
                await next();
            }
        }
    }
}