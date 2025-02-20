using MediatR;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using CryptoTracker.API.Validation;
using Refit;
using CryptoTracker.API.Services;
using CryptoTracker.API.Services.Interfaces;
using Microsoft.Extensions.Options;
using CryptoTracker.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddFluentValidation(config => 
    {
        config.RegisterValidatorsFromAssemblyContaining<Program>();
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CoinGecko API client
builder.Services.AddRefitClient<ICoinGeckoClient>()
    .ConfigureHttpClient(c => {
        c.BaseAddress = new Uri("https://api.coingecko.com/api/v3");
        c.DefaultRequestHeaders.Add("Accept", "application/json");
    });

builder.Services.Configure<CoinGeckoSettings>(
    builder.Configuration.GetSection("CoinGecko"));

// Configure CoinGecko API client
var coinGeckoSettings = builder.Configuration
    .GetSection("CoinGecko")
    .Get<CoinGeckoSettings>();

builder.Services.AddScoped<ICryptoService, CryptoService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:5173") // Default Vite port
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Add MediatR with validation pipeline
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

app.Run();