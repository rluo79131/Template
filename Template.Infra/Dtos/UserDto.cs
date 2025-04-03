namespace Template.Infra.Dtos
{
    /// <summary>
    /// 使用者DTO
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
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
    }
}
