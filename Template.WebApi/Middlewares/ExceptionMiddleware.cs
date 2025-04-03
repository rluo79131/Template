using System.Text;
using Template.BussinessLogic;
using Template.Infra.Dtos;

namespace Template.WebApi.Middlewares
{
    /// <summary>
    /// 例外處理中介服務
    /// </summary>
    /// <param name="Next"></param>
    public class ExceptionMiddleware(RequestDelegate Next)
    {
        public async Task Invoke(HttpContext context, IInfraService infraService)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                var infraDto = new InfraDto()
                {
                    Method = context.Request.Method,
                    Url = context.Request.Path.Value,
                    Message = ex.ToString(),
                };

                if (context.Request.Method == "POST")
                {
                    context.Request.Body.Seek(0, SeekOrigin.Begin);

                    using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                    {
                        var body = await reader.ReadToEndAsync();
                        infraDto.Body = body.Replace("\n    ", "").Replace("\r\n", "");
                    }
                }
                await infraService.CreateApiErrorLog(infraDto);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
            }
        }
    }
}
