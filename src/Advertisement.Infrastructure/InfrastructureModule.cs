using Advertisement.Application.Services.User.Interfaces;
using Advertisement.Infrastructure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Advertisement.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {
            services
                .AddHttpContextAccessor()
                .AddScoped<IClaimsAccessor, HttpContextClaimsAccessor>();
            
            return services;
        }
    }
}