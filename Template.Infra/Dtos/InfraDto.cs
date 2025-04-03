namespace Template.Infra.Dtos
{
    /// <summary>
    /// 基礎設施DTO
    /// </summary>
    public class InfraDto
    {
        /// <summary>
        /// 方法
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// URL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// A異常訊息
        /// </summary>
        public string Message { get; set; }
    }
}
