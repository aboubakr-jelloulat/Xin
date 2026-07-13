using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));

});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("DefaultConnection"));
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Register health checks
builder.Services.AddHealthChecks()
    .AddNpgSql(
        connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
        healthQuery: "SELECT 1;", name: "CatalogDb", failureStatus: HealthStatus.Unhealthy);


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks("/health", new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse});

app.MapCarter();

app.Run();
