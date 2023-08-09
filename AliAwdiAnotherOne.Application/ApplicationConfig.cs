using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
namespace AliAwdiAnotherOne.Application
{
    public static  class ApplicationConfig

    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly= typeof(ApplicationConfig).Assembly;   
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assembly));
            services.AddValidatorsFromAssembly(assembly);
            return services;
        }
    }
}
