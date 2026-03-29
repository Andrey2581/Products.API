using Product.Api.Configurations;
using Product.CrossCutting.Configurations;
using Product.Application.Configurations;
using Product.Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureApi(builder.Configuration)
    .ConfigureCrossCutting()
    .ConfigureApplication(builder.Configuration)
    .ConfigurePersistence(builder.Configuration);

var app = builder.Build();

app.UseApi()
    .Run();

