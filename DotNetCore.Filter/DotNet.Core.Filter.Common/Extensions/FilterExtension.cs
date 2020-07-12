using Microsoft.AspNetCore.Mvc;
using DotNetCore.Filter.Common.Filters;

namespace DotNetCore.Filter.Common.Extensions
{
    /// <summary>
    /// Class FilterExtension
    /// </summary>
    public static class FilterExtension
    {
        /// <summary>
        /// Adds the message filter.
        /// </summary>
        /// <param name="options">The options.</param>
        public static void AddMessageFilter(this MvcOptions options)
        {
            options.Filters.Add<ExceptionFilter>();
            options.Filters.Add<MessageActionFilter>();
        }
    }
}