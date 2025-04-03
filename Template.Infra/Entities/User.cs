using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Infra.Entities
{
    /// <summary>
    /// 使用者資料表
    /// </summary>
    [Table("Users")]
    public class User
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 手機號碼
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 電子信箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
