using Discount.gRPC.Data;
using Discount.gRPC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddDbContext<DiscountContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DataBase")));

var app = builder.Build();

await app.UseMigration();

app.MapGrpcService<DiscountService>();

app.Run();
