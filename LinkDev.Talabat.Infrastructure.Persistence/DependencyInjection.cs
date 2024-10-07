using LinkDev.Talabat.Infrastructure.Persistence._Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LinkDev.Talabat.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersisitenceServices(this IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<StoreContext>((OptionsBuilder) =>
            {

                OptionsBuilder.UseSqlServer(configuration.GetConnectionString("StoreContext"));


            }
            /*, ContextLifetime : ServiceLifetime.Scoped,optionsLifetime:ServiceLifetime.Scoped*/);


          return services;
        }








    }
}
