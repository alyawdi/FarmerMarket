using AliAwdiAnotherOne.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace AliAwdiAnotherOne.Infrastructure.Config
{
    public static class InfrastructureConfig
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
            services.AddDatabase();
            return services;
        }
        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }

  
}
