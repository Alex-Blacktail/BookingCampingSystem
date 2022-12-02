using Booking.System.WebApi.Data;
using Booking.System.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Booking.System.Application.Mappings;

namespace Booking.System.WebApi
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services
                .AddIdentity<AppUser, IdentityRole>(io =>
                {
                    io.Password.RequireDigit = true;
                    io.Password.RequireLowercase = true;
                    io.Password.RequireUppercase = true;
                    io.Password.RequireNonAlphanumeric = false;
                    io.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<SecurityDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureMapping(this IServiceCollection services) 
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            var mappingConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<UserMappingProfile>();
            });

            services.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}
