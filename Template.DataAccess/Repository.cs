using Microsoft.EntityFrameworkCore;

namespace Template.DataAccess
{
    /// <summary>
    /// 存取庫介面
    /// </summary>
    /// <typeparam name="TEntity">實體物件</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// 建立資料
        /// </summary>
        /// <param name="entity">實體</param>
        /// <returns></returns>
        Task Create(TEntity entity);

        /// <summary>
        /// 讀取資料
        /// </summary>
        /// <param name="id">實體ID</param>
        /// <returns></returns>
        Task<TEntity?> Read(int id);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="entity">實體</param>
        void Update(TEntity entity);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="entity">實體</param>
        void Delete(TEntity entity);
    }

    /// <summary>
    /// 存取庫介面
    /// </summary>
    /// <typeparam name="TEntity">實體</typeparam>
    /// <param name="Context">DbContext物件</param>
    public class Repository<TEntity>(DbContext Context) : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 建立資料
        /// </summary>
        /// <param name="entity">實體</param>
        /// <returns></returns>
        public async Task Create(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        /// <summary>
        /// 讀取資料
        /// </summary>
        /// <param name="id">實體ID</param>
        /// <returns></returns>
        public async Task<TEntity?> Read(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="entity">實體</param>
        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="entity">實體</param>
        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}
