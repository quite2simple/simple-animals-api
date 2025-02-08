using Microsoft.AspNetCore.HttpOverrides;
using SimpleAnimalAPI.Common.Generators;
using SimpleAnimalAPI.Modules.Animals;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console().CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSerilog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAnimalGenerator, RandomAnimalGenerator>();
builder.Services.AddSingleton<AnimalsService>();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseForwardedHeaders();
app.MapControllers();

app.Run();