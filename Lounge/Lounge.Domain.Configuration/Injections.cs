using Microsoft.Extensions.DependencyInjection;

namespace Lounge.Domain.Configuration
{
    public static class Injections
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDatabaseService, DatabaseService>();
            return services;
        }
    }
}