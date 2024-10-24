using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts.EF_Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectioString = builder.Configuration["ConnectionStrings:sqlServer"];

builder.Services.AddDbContext<IDataBaseContext, DataBaseContext>(options => options.UseSqlServer(ConnectioString));

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
