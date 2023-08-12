using Microsoft.Extensions.DependencyInjection;
using AliAwdiAnotherOne.Application.Repositories;
using AliAwdiAnotherOne.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;



namespace AliAwdiAnotherOne.Infrastructure.Data
{
    public static class InfrastructureConfig

    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped < IFarmerMarketRepo, FarmerMarketRepository>();
            services.AddScoped<IRestaurantOrderRepo, RestaurantOrderRepository>();

            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var connectionString = "Data Source=" + Path.Join(path, "AliAwdiAnotherOne.db");

         /*   services.AddDbContext<AppDbContext>(options
                => options.UseSqlite(connectionString));*/

/*            services.AddHostedService<AppInitializer>();
*/
            return services;
        }
    }
}
