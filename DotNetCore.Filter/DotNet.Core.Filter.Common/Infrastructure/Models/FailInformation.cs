namespace DotNetCore.Filter.Common.Infrastructure.Models
{
    /// <summary>
    /// 失敗訊息
    /// </summary>
    public class FailInformation
    {
        /// <summary>
        /// 專案名稱
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 錯誤代碼
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 詳細描述
        /// </summary>
        public string Description { get; set; }
    }
}