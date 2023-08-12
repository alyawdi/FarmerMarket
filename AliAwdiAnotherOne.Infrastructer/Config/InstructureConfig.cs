
using AliAwdiAnotherOne.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
namespace AliAwdiAnotherOne.Infrastructure.Config
{
    public static class InfrastructureConfig
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            services.AddDatabase();
            return services;
        }
    }
}
