using Demo.Cache.Api.Data.Context;
using Demo.Cache.Api.Data.Repositories;
using Demo.Cache.Api.Stores;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("DataContext"));
builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();

var dataContext = app.Services.CreateScope()
    .ServiceProvider.GetRequiredService<DataContext>();

dataContext.Generate();

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