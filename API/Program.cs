using System.Reflection;
using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());
builder.Services.AddControllers();
builder.Services.AddAplicacionServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureCors();

builder.Services.AddDbContext<SkeletonAppWebApiContext>(Options =>
{
    string connectionString = builder.Configuration.GetConnectionString("conexMysql");
    Options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
