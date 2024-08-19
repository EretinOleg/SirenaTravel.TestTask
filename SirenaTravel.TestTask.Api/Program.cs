using Serilog;
using SirenaTravel.TestTask.Api.Middleware;
using SirenaTravel.TestTask.Application;
using SirenaTravel.TestTask.Infrastructure;
using SirenaTravel.TestTask.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog((services, config) =>
    config.ReadFrom.Configuration(builder.Configuration));

builder.Services
    .AddApplication()
    .AddPersistence()
    .AddInfrastructure();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
