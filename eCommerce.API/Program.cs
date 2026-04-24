using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfiles>());

var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
