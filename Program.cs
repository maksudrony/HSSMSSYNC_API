using HSSMSSYNC_API.Interfaces;
using HSSMSSYNC_API.Repositories;
using HSSMSSYNC_API.Services;
using Oracle.ManagedDataAccess.Client;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Oracle Connection securely
builder.Services.AddTransient<IDbConnection>(sp =>
    new OracleConnection(builder.Configuration.GetConnectionString("OracleDbConnection"))
);

// Register Repositories
// যখন কেউ IRemoteAccUserRepository চাইবে → তাকে RemoteAccUserRepository দিবে
builder.Services.AddScoped<HSSMSSYNC_API.Interfaces.IRemoteAccUserRepository, HSSMSSYNC_API.Repositories.RemoteAccUserRepository>();

// 3. Register Services
builder.Services.AddScoped<HSSMSSYNC_API.Interfaces.IRemoteAccUserService, HSSMSSYNC_API.Services.RemoteAccUserService>();

builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
