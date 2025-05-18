using Microsoft.EntityFrameworkCore;
using Question2.Services.Interfaces;
using Question2.Services;
using Question2.Database;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddDbContext<SageModel>(options => options.UseSqlServer(config.GetConnectionString("SageDB")));
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IDatabaseService, DatabaseService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
