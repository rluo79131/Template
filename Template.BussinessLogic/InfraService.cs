using Template.DataAccess;
using Template.Infra.Dtos;
using Template.Infra.Entities;

namespace Template.BussinessLogic
{
    /// <summary>
    /// 基礎設施服務介面
    /// </summary>
    public interface IInfraService
    {
        /// <summary>
        /// 建立異常紀錄資料
        /// </summary>
        /// <param name="dto">基礎設施DTO</param>
        /// <returns></returns>
        Task CreateApiErrorLog(InfraDto dto);
    }

    /// <summary>
    /// 基礎設施服務
    /// </summary>
    /// <param name="UnitOfWork">工作單元</param>
    public class InfraService(IUnitOfWork UnitOfWork) : IInfraService
    {
        /// <summary>
        /// 建立異常紀錄資料
        /// </summary>
        /// <param name="dto">基礎設施DTO</param>
        /// <returns></returns>
        public async Task CreateApiErrorLog(InfraDto dto)
        {
            var newLog = new ApiErrorLog()
            {
                Method = dto.Method,
                Url = dto.Url,
                Body = dto.Body,
                Message = dto.Message,
                CreatedAt = DateTime.Now,
            };

            await UnitOfWork.Repository<ApiErrorLog>().Create(newLog);
            UnitOfWork.SaveChanges();
        }
    }
}
