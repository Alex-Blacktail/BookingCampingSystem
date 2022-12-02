using Booking.System.WebApi;
using Booking.System.WebApi.Data;
using Booking.System.WebApi.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var connectionString = config.GetConnectionString("Default");
builder.Services.AddDbContext<SecurityDbContext>(options => options.UseNpgsql(connectionString));

//Конфигурация идентити

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

builder.Services.ConfigureJWT(config.GetSection("JwtConfig").Get<JWTSettings>());

//Конфигурация Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

//Controllers, Api

builder.Services.ConfigureControllers();
builder.Services.AddEndpointsApiExplorer();

//Shmagger

builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
