using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers
builder.Services.AddControllers().AddJsonOptions(options => options.
JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

//Add AutoMapper as service
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//Add Fluent Validations
builder.Services.AddFluentValidationAutoValidation();

//Add swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseSwagger();//Adds endpoint that can serve swagger json

app.UseSwaggerUI();//Adds endpoint that can serve swagger ui

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


