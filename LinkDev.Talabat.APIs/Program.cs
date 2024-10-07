
using LinkDev.Talabat.Infrastructure.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LinkDev.Talabat.APIs
{
    public class Program
    {
        //[FromServices]
        //public static StoreContext StoreContext { get; set; } = null!;
        //static Program() { }    

        public static async Task  Main(string[] args
            /*StoreContext dbContext */
            )
        {


            //StoreContext dbContext  /*new StoreContext()*/;
;




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

            var scope = app.Services.CreateAsyncScope();
            var services = scope.ServiceProvider;
            var dbContext = services.GetRequiredService<StoreContext>();
            // Ask Runtime Env for Object from " StoreContext" Serivce Explicitly.
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            //var logger = services.GetRequiredService<ILogger>();        
            try { 
                var pendingMigrations = dbContext.Database.GetPendingMigrations();
           
                if(pendingMigrations.Any())
                await dbContext.Database.MigrateAsync(); //Update-Database


                await StoreContextSeed.SeedAsync(dbContext);
            }
            catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error has been occured during applying the migrations."); 
            }
            finally
            {
                await scope.DisposeAsync();
            }


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
