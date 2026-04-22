using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
