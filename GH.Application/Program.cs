using AutoMapper;
using GH.Domain.Dto;
using GH.Domain.Entities;
using GH.Domain.Interfaces;
using GH.Infra.Data.Context;
using GH.Infra.Data.Repository;
using GH.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//builder.Services.AddDbContext<ApplicationContext>(options =>
//options.UseSqlServer(
//                  builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseInMemoryDatabase("GH"));

builder.Services.AddCors(options => options.AddPolicy("Cors", options => options.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()));

builder.Configuration.AddJsonFile("appsettings.json", false, true);

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBaseRepository<Order>, BaseRepository<Order>>();
builder.Services.AddScoped<IBaseRepository<Extra>, BaseRepository<Extra>>();
builder.Services.AddScoped<IBaseRepository<Sandwich>, BaseRepository<Sandwich>>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ISandwichExtrasService, SandwichExtrasService>();

builder.Services.AddSingleton(new MapperConfiguration(config =>
{
    config.CreateMap<CreateOrderDto, Order>();
    config.CreateMap<SandwichDto, Sandwich>();  
    config.CreateMap<ExtraDto, Extra>();

}).CreateMapper());

builder.Services.AddControllersWithViews()
               .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling =
                   Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseAuthorization();

app.MapControllers();

app.Run();
