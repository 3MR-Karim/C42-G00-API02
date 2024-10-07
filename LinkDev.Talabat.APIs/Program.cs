
using LinkDev.Talabat.Infrastructure.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LinkDev.Talabat.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            #region Configure Services
            webApplicationBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();



            webApplicationBuilder.Services.AddSwaggerGen().AddPersisitenceServices(webApplicationBuilder.Configuration);
            webApplicationBuilder.Services.AddDbContext<StoreContext>((OptionsBuilder) =>
            {

                OptionsBuilder.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("StoreContext"));
            }/*contextLifetime:ServiceLifetime.Scoped,optionsLifetime:ServiceLifetime.Scoped*/);
            #endregion

            var app = webApplicationBuilder.Build();

            #region Configure Kestral Middlwares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
