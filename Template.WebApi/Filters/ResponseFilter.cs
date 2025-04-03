using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Template.WebApi.Models;

namespace Template.WebApi.Filters
{
    /// <summary>
    /// 回應過濾器
    /// </summary>
    public class ResponseFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 狀態碼
        /// </summary>
        public static Dictionary<int, string> StatusCodePairs => new()
        {
            { 200, "執行成功"},
            { 400, "請求錯誤"},
            { 401, "權限不合法"},
            { 404, "資料不合法"},
            { 500, "服務異常"},
        };

        /// <summary>
        /// 執行程序
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult || context.Result is StatusCodeResult)
            {
                if (context.Result is ObjectResult)
                {
                    var objectResult = context.Result as ObjectResult;
                    var objectResult_StatusCode = objectResult!.StatusCode!.Value;
                    var objectResult_ApiResponse = new ApiResponse()
                    {
                        Result = StatusCodePairs[objectResult_StatusCode],
                        Data = objectResult.Value,
                    };

                    context.Result = new ObjectResult(objectResult_ApiResponse)
                    {
                        StatusCode = objectResult_StatusCode,
                    };

                    return;
                }

                var statusCodeResult = context.Result as StatusCodeResult;
                var statusCodeResult_StatusCode = statusCodeResult!.StatusCode;
                var statusCodeResult_ApiResponse = new ApiResponse()
                {
                    Result = StatusCodePairs[statusCodeResult_StatusCode],
                };

                context.Result = new ObjectResult(statusCodeResult_ApiResponse)
                {
                    StatusCode = statusCodeResult_StatusCode,
                };
            }
        }
    }
}
