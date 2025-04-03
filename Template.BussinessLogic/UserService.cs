using Template.DataAccess;
using Template.Infra.Dtos;
using Template.Infra.Entities;

namespace Template.BussinessLogic
{
    /// <summary>
    /// 使用者服務介面
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 建立使用者資料
        /// </summary>
        /// <param name="dto">使用者DTO</param>
        /// <returns></returns>
        Task CreateUser(UserDto dto);

        /// <summary>
        /// 取得使用者資料
        /// </summary>
        /// <param name="id">使用者ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<User> GetUser(int id);

        /// <summary>
        /// 更新使用者資料
        /// </summary>
        /// <param name="dto">使用者DTO</param>
        /// <returns></returns>
        Task UpdateUser(UserDto dto);

        /// <summary>
        /// 刪除使用者資料
        /// </summary>
        /// <param name="id">使用者ID</param>
        /// <returns></returns>
        Task DeleteUser(int id);
    }

    /// <summary>
    /// 使用者服務
    /// </summary>
    /// <param name="UnitOfWork">工作單元</param>
    public class UserService(IUnitOfWork UnitOfWork) : IUserService
    {
        /// <summary>
        /// 建立使用者資料
        /// </summary>
        /// <param name="dto">使用者DTO</param>
        /// <returns></returns>
        public async Task CreateUser(UserDto dto)
        {
            var newUser = new User()
            {
                Name = dto.Name,
                Gender = dto.Gender,
                Phone = dto.Phone,
                Email = dto.Email,
                CreatedAt = DateTime.Now,
            };

            await UnitOfWork.Repository<User>().Create(newUser);
            UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// 取得使用者資料
        /// </summary>
        /// <param name="id">使用者ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<User> GetUser(int id)
        {
            var user = await UnitOfWork.Repository<User>().Read(id);
            if (user == null)
            {
                throw new Exception("無此 User 資料");
            }

            return user;
        }

        /// <summary>
        /// 更新使用者資料
        /// </summary>
        /// <param name="dto">使用者DTO</param>
        /// <returns></returns>
        public async Task UpdateUser(UserDto dto)
        {
            var user = await GetUser(dto.Id);
            user.Name = dto.Name;
            user.Gender = dto.Gender;
            user.Phone = dto.Phone;
            user.Email = dto.Email;
            user.UpdatedAt = DateTime.Now;

            UnitOfWork.Repository<User>().Update(user);
            UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// 刪除使用者資料
        /// </summary>
        /// <param name="id">使用者ID</param>
        /// <returns></returns>
        public async Task DeleteUser(int id)
        {
            var user = await GetUser(id);

            UnitOfWork.Repository<User>().Delete(user);
            UnitOfWork.SaveChanges();
        }
    }
}
