var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiServices(builder.Configuration).AddApplicationServices().AddInfrastructureServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.InitialiseDatabaseAsync();
}

app.UseApiServices();

app.Run();
