using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Order.Application.Extensions
{
    public static class ApplicationRegistrations
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }

    }
}
