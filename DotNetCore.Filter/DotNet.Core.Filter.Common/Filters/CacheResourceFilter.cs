using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCore.Filter.Common.Filters
{
    /// <summary>
    /// Class CacheResourceFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncResourceFilter" />
    public class CacheResourceFilter : IAsyncResourceFilter
    {
        private static readonly Dictionary<string, ObjectResult> _cache = new Dictionary<string, ObjectResult>();

        /// <summary>
        /// Called asynchronously before the rest of the pipeline.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutingContext" />.</param>
        /// <param name="next">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResourceExecutionDelegate" />. Invoked to execute the next resource filter or the remainder
        /// of the pipeline.</param>
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var cacheKey = context.HttpContext.Request.Path.ToString();

            if (_cache != null && _cache.ContainsKey(cacheKey))
            {
                var cacheValue = _cache[cacheKey];
                if (cacheValue != null)
                {
                    context.Result = cacheValue;
                }
            }
            else
            {
                var executedContext = await next();

                var result = executedContext.Result as ObjectResult;
                if (result != null)
                {
                    _cache.Add(cacheKey, result);
                }
            }
        }
    }
}