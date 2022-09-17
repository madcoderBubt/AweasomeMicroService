using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.Extensions.Hosting;
using MMLib.Ocelot.Provider.AppConfiguration;
using Microsoft.OpenApi.Models;
using MMLib.SwaggerForOcelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
        optional: true, reloadOnChange: true)
    //.AddJsonFile($"appsettings.local.json", optional: true, reloadOnChange: true)
    .AddOcelotWithSwaggerSupport((o) => {
        o.Folder = "Configuration";
    })
    .AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOcelot()
        .AddAppConfiguration();
builder.Services.AddSwaggerForOcelot(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwaggerForOcelotUI(opt =>
    {
        opt.DownstreamSwaggerHeaders = new[]
        {
            new KeyValuePair<string, string>("Key", "Value"),
            new KeyValuePair<string, string>("Key2", "Value2"),
        };
    }).UseOcelot().Wait();

app.UseAuthorization();

app.MapControllers();

app.Run();
