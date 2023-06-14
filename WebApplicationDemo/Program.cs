using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Database;
using WebApplicationDemo.Services;
using WebApplicationDemo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();

//builder.Services.AddSingleton<ICounterService, CounterService>();
builder.Services.AddScoped<ICounterService, CounterInFileService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
