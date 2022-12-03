using Booking.System.Application;
using Booking.System.Application.Camps;
using Booking.System.Application.Identity;
using Booking.System.Domain;
using Booking.System.WebApi;
using Booking.System.WebApi.Data;
using Booking.System.WebApi.Extensions;
using Booking.System.Application.Identity;
using Microsoft.EntityFrameworkCore;
using Booking.System.Application.Childs;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureSerilogLogging();

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
builder.Services.AddScoped<ICampCardRepository, CampCardRepository>();
builder.Services.AddScoped<IChildRepository, ChildRepository>();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(config.GetSection("JwtConfig").Get<JWTSettings>());

builder.Services.ConfigureControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});
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

app.ConfigureExceptionHandler();

app.MapControllers();
app.Run();
