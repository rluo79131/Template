using Microsoft.AspNetCore.Mvc;
using Template.BussinessLogic;
using Template.Infra.Dtos;

namespace Template.WebApi.Controllers
{
    /// <summary>
    /// 使用者控制器
    /// </summary>
    /// <param name="UserService"></param>
    [ApiController, Route("api/[controller]s")]
    public class UserController(IUserService UserService) : ControllerBase
    {
        /// <summary>
        /// 建立使用者資料
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto dto)
        {
            await UserService.CreateUser(dto);
            return Ok();
        }

        /// <summary>
        /// 取得使用者資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await UserService.GetUser(id);
            return Ok(result);
        }

        /// <summary>
        /// 更新使用者資料
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<IActionResult> UpdateUser(UserDto dto)
        {
            await UserService.UpdateUser(dto);
            return Ok();
        }

        /// <summary>
        /// 刪除使用者資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await UserService.DeleteUser(id);
            return Ok();
        }
    }
}
