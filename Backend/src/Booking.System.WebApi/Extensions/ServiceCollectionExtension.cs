using AutoMapper;

using System.Text;

using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Booking.System.Application;
using Booking.System.WebApi.Data;
using Booking.System.Domain.Identity;
using Booking.System.Application.Mappings;
using Serilog;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Booking.System.WebApi.Extensions
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
                map.AddProfile<CampMappingProfile>();
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

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "API для работы с бронированием детских путевок",
                    Version = "v1.0",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "Name"
                    }
                });

                c.ResolveConflictingActions(apiDesription => apiDesription.First());

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

            });
        }

        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
                {
                    Duration = 30
                });
            });
        }
       
        public static void ConfigureResponseCaching(this IServiceCollection services)
        {
            services.AddResponseCaching();
        }

        public static void ConfigureSerilogLogging(this IHostBuilder host)
        {
            host.ConfigureLogging((context, logBuilder) =>
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(context.Configuration)
                    .Enrich.FromLogContext()
                    .CreateLogger();

                logBuilder
                    .AddSerilog(Log.Logger)
                    .AddConfiguration(context.Configuration.GetSection("Serilog"))
                    .AddConsole()
                    .AddDebug();
            });
        }
    }
}
