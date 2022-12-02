using Microsoft.AspNetCore.Identity;
using Booking.System.WebApi.Data;
using Booking.System.WebApi.Identity.Models;

namespace Booking.System.WebApi.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>();
            var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);

            identityBuilder.AddEntityFrameworkStores<SecurityDbContext>();
            identityBuilder.AddSignInManager<SignInManager<AppUser>>();

            return services;
        }
    }
}