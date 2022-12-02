using AutoMapper;

using System.Text;

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Booking.System.WebApi.Data;
using Booking.System.WebApi.Settings;
using Booking.System.Domain.Identity;
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

        public static void ConfigureJWT(this IServiceCollection services, JWTSettings settings) 
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = settings.ValidIssuer,
                        ValidAudience = settings.ValidAudience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Secret))
                    };
                });
        }
    }
}
