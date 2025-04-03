namespace Template.WebApi.Models
{
    /// <summary>
    /// API回應
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// 回應結果
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 回應資料
        /// </summary>
        public object? Data { get; set; }
    }
}
