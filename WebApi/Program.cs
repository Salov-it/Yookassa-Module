using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Yookassa.Application;
using Yookassa.Application.Configs;
using Yookassa.Application.CQRS.Command.PostCreatePaymentCommand;
using Yookassa.Application.Interface;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new Yookassa.Application.Mapping.AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
});


builder.Services.AddYookassaApplication();
builder.Services.AddHttpClient();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
