using Application.Interfaces;
using Application.Services.DetailPreInvoiceServices.Command;
using Application.Services.DetailPreInvoiceServices.Queries;
using Application.Services.DiscountServices.Command;
using Application.Services.DiscountServices.Queries;
using Application.Services.PreInvoiceHeaderServices.Command;
using Application.Services.PreInvoiceHeaderServices.Queries;
using Domain.Entities;
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


//DetailPreInvoice Services
builder.Services.AddScoped<AddDetailPreInvoiceService>();
builder.Services.AddScoped<DeleteDetailPreInvoiceService>();
builder.Services.AddScoped<UpdateDetailPreInvoiceService>();
builder.Services.AddScoped<GetAllDetailPreInvoiceService>();
builder.Services.AddScoped<GetDetailPreInvoiceService>();

//PreInvoiceHeader Services
builder.Services.AddScoped<AddPreInvoiceHeaderService>();
builder.Services.AddScoped<DeletePreInvoiceHeaderService>();
builder.Services.AddScoped<UpdatePreInvoiceHeaderService>();
builder.Services.AddScoped<GetAllPreInvoiceHeaderService>();
builder.Services.AddScoped<GetPreInvoiceHeaderService>();

//Discount Services
builder.Services.AddScoped<AddDiscountService>();
builder.Services.AddScoped<DeleteDiscountService>();
builder.Services.AddScoped<UpdateDiscountService>();
builder.Services.AddScoped<GetAllDiscountService>();
builder.Services.AddScoped<GetDiscountService>();


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
