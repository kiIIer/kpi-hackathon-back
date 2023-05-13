using Idk.Application.Mapper.Subject;
using Idk.Domain.Data;
using Idk.Domain.Models;
using Idk.Web.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Register();
builder.Services.AddDbContext<IdkContext>((o) =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using var scope = app.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;
var recurringJobManager = serviceProvider.GetService<ISubjectMapper>();
try
{
    var a = recurringJobManager.Map(new Subject());
}
catch (Exception e)
{
    Console.WriteLine(e);
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
