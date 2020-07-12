using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using DotNetCore.Filter.Common.Infrastructure.Models;

namespace DotNetCore.Filter.Common.Filters
{
    /// <summary>
    /// Class MessageActionFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter"/>
    public class MessageActionFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Called asynchronously before the action, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext"/>.</param>
        /// <param name="next">
        /// The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate"/>. Invoked to
        /// execute the next action filter or the action itself.
        /// </param>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var executedContext = await next();

            var result = executedContext.Result as ObjectResult;

            if (result != null
             && !(result.Value is HttpResponseMessage)
             && !(result.Value is SuccessResultViewModel<object>)
             && !(result.Value is FailResultViewModel)
             && !(result.Value is SuccessResultViewModel<ModelStateDictionary>))
            {
                var responseModel = new SuccessResultViewModel<object>
                {
                    Version = "1.0",
                    Method = $"{context.HttpContext.Request.Path}.{context.HttpContext.Request.Method}",
                    Status = "Success",
                    Id = Guid.NewGuid().ToString(),
                    Data = result.Value
                };

                executedContext.Result = new ObjectResult(responseModel)
                {
                    StatusCode = 200
                };
            }
        }
    }
}