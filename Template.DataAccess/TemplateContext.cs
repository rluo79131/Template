using Microsoft.EntityFrameworkCore;
using Template.Infra.Entities;

namespace Template.DataAccess
{
    /// <summary>
    /// DbContext物件
    /// </summary>
    /// <param name="Options"></param>
    public class TemplateContext(DbContextOptions<TemplateContext> Options) : DbContext(Options)
    {
        /// <summary>
        /// API異常紀錄資料表
        /// </summary>
        public virtual DbSet<ApiErrorLog> ApiErrorLogs { get; set; }

        /// <summary>
        /// 使用者資料表
        /// </summary>
        public virtual DbSet<User> Users { get; set; }
    }
}
