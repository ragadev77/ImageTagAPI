using Microsoft.EntityFrameworkCore;
using ImageTagApi.Models;
using ImageTagApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPictureRepository, PictureRepository>();
// builder.Services.AddDbContext<PictureContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlServer")));
builder.Services.AddDbContext<PictureContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")));

builder.Services.AddHealthChecks();
var app = builder.Build();
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    c.RoutePrefix = string.Empty;
                    c.ConfigObject.DefaultModelRendering = Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model;
                    c.ConfigObject.ShowCommonExtensions = true;
                });    
}

// app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();


