using System;
using System.Net;
using System.Threading.Tasks;
using DotNetCore.Filter.Common.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCore.Filter.Common.Filters
{
    /// <summary>
    /// Class AuthorizationFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter" />
    public class AuthorizationFilter : IAsyncAuthorizationFilter
    {
        /// <summary>
        /// Called early in the filter pipeline to confirm request is authorized.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext" />.</param>
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var cookies = context.HttpContext.Request.Cookies;

            cookies.TryGetValue("token", out string token);

            if (token.Equals("123456"))
            {
                var response = new FailResultViewModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Method = $"{context.HttpContext.Request.Path}.{context.HttpContext.Request.Method}",
                    Status = "UnAuthorized",
                    Version = "1.0",
                    Error = new FailInformation()
                    {
                        Domain = "ProjectName",
                        Message = "未授權",
                        Description = "授權驗證失敗"
                    }
                };

                context.Result = new ObjectResult(response)
                {
                    // 401
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };
            }
        }
    }
}