using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Template.BussinessLogic;
using Template.DataAccess;
using Template.WebApi.Filters;
using Template.WebApi.Middlewares;

namespace Template.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //註冊回應過濾器、設定回應屬性名稱格式(大駝峰)
            builder.Services.AddMvc(options => options.Filters.Add(typeof(ResponseFilter)))
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            //註冊 DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<TemplateContext>(options => options.UseSqlServer(connectionString));

            //註冊 DI
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IInfraService, InfraService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExceptionMiddleware>();//註冊例外處理中介服務
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
