using Microsoft.EntityFrameworkCore;

namespace Template.DataAccess
{
    /// <summary>
    /// 工作單元介面
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 存取庫
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        /// <summary>
        /// 儲存資料改變
        /// </summary>
        void SaveChanges();
    }

    /// <summary>
    /// 工作單元
    /// </summary>
    /// <param name="Context">DbContext物件</param>
    public class UnitOfWork(TemplateContext Context) : IUnitOfWork
    {
        /// <summary>
        /// 存取庫
        /// </summary>
        private readonly Dictionary<Type, object> Repositories = [];

        /// <summary>
        /// 取得存取庫
        /// </summary>
        /// <typeparam name="TEntity">實體</typeparam>
        /// <returns></returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (Repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)Repositories[typeof(TEntity)];
            }

            var repository = new Repository<TEntity>(Context);
            Repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        /// <summary>
        /// 儲存資料改變
        /// </summary>
        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// 銷毀工作單元
        /// </summary>
        public void Dispose()
        {
            //當程序結束後，服務會執行此方法來銷毀工作單元在記憶體的配置。
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
