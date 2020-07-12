using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCore.Filter.Common.Filters
{
    /// <summary>
    /// Class ResultFilter
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncResultFilter" />
    public class ResultFilter : IAsyncResultFilter
    {
        /// <summary>
        /// Called asynchronously before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResultExecutingContext" />.</param>
        /// <param name="next">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ResultExecutionDelegate" />. Invoked to execute the next result filter or the result itself.</param>
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!(context.Result is EmptyResult))
            {
                var headerName = "OnResultExecuting";

                var headerValue = new string[] { "ResultExecuting Successfully" };

                context.HttpContext.Response.Headers.Add(headerName, headerValue);

                await next();

                // 無法在執行後加入 Header，因為 Response 已經開始，此時 Response 可能已經到 Client 端那便無法修改了
            }
            else
            {
                // 若已經被其他 Filter 攔截回傳或是接收到的 context 是空的，則取消 Result 回傳
                // 但是若提前被攔截則並不會進到 ResultFilter
                context.Cancel = true;
            }
        }
    }
}