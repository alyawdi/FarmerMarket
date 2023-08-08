using AliAwdiAnotherOne;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FluentValidation;
using NuGet.Protocol.Core.Types;
using System;
using AliAwdiAnotherOne.Domain.Entities;
using AliAwdiAnotherOne.Application.Commands.FarmerMarketCommands.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
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
