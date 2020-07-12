namespace DotNetCore.Filter.Common.Extensions
{
    /// <summary>
    /// Class StringExtensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 字串為null或空字串
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><c>true</c> if [is null or empty] [the specified value]; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// 字串為null或空字串或空白
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// <c>true</c> if [is null or white space] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// 字串不為null
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool NotEqualNull(this string value)
        {
            return !(value is null);
        }
    }
}