using Product.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureApi(builder.Configuration);

var app = builder.Build();

app.UseApi().Run();

