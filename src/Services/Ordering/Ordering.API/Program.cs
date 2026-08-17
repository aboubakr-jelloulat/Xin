var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices().AddApplicationServices().AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    await app.InitialiseDatabaseAsync();
}

app.UseApiServices();

app.Run();
