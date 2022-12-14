using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.System.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
