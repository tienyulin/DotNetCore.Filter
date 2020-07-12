using Newtonsoft.Json;

namespace DotNetCore.Filter.Common.Infrastructure.Models
{
    /// <summary>
    /// 成功的ViewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SuccessResultViewModel<T>
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
        /// 資料內容
        /// </summary>
        [JsonProperty(PropertyName = "data", Order = 4)]
        public T Data { get; set; }
    }
}