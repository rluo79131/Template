using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Infra.Entities
{
    /// <summary>
    /// API異常紀錄資料表
    /// </summary>
    [Table("ApiErrorLogs")]
    public class ApiErrorLog
    {
        /// <summary>
        /// API異常紀錄ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
        /// 異常訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 建立方法
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
