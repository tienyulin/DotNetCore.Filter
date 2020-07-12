using Newtonsoft.Json;

namespace DotNetCore.Filter.Common.Infrastructure.Models
{
    /// <summary>
    /// 失敗的ViewModel
    /// </summary>
    public class FailResultViewModel
    {
        /// <summary>
        /// Api版本
        /// </summary>
        [JsonProperty(PropertyName = "apiVersion", Order = 0)]
        public string Version { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        [JsonProperty(PropertyName = "method", Order = 1)]
        public string Method { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [JsonProperty(PropertyName = "status", Order = 2)]
        public string Status { get; set; }

        /// <summary>
        /// 編號
        /// </summary>
        [JsonProperty(PropertyName = "id", Order = 3)]
        public string Id { get; set; }

        /// <summary>
        /// 失敗訊息
        /// </summary>
        [JsonProperty(PropertyName = "error", Order = 4)]
        public FailInformation Error { get; set; }
    }
}