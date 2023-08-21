using Google.Api;
using gRPCwithDotnet.Data;
using gRPCwithDotnet.Data.Interfaces;
using gRPCwithDotnet.Extensions;
using gRPCwithDotnet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<gRPCDataContext>(x=>x.UseSqlite("Data Source = gRPCDb"));

// Add services to the container.
builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient<IProductDbContext, ProductDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<ProductService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
