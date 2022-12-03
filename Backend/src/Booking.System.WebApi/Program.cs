using Booking.System.Application;
using Booking.System.Application.Identity;
using Booking.System.Domain;
using Booking.System.WebApi;
using Booking.System.WebApi.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddOptions();
builder.Services.Configure<JWTSettings>(config.GetSection("JwtConfig"));

builder.Services.AddApplication();

builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureMapping();

var connectionString = config.GetConnectionString("Default");
builder.Services.AddDbContext<SecurityDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDbContext<CampDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUserAuthenticationRepository, UserAuthenticationRepository>();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(config.GetSection("JwtConfig").Get<JWTSettings>());

builder.Services.ConfigureControllers();
builder.Services.AddEndpointsApiExplorer();

//Shmagger

builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1.0/swagger.json", "Main API");
    });
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
