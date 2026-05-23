using Microsoft.OpenApi.Models;
using Palyio.API.Router;
using Palyio.Application.Ports.Repositories;
using Palyio.Application.Ports.UseCases;
using Palyio.Application.Ports.UseCases.LedgerEntry;
using Palyio.Application.Ports.UseCases.Transaction;
using Palyio.Application.UseCases;
using Palyio.Infrastructure.Persistence;
using Palyio.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Palyio", Version = "v1" });
});

var mongoSettings = builder.Configuration.GetSection("MongoDB").Get<MongoDbSettings>()
    ?? throw new InvalidOperationException("MongoDB settings are missing.");

builder.Services.AddSingleton(mongoSettings);
builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ILedgerEntryRepository, LedgerEntryRepository>();

builder.Services.AddScoped<IUserUseCase, UserUseCase>();
builder.Services.AddScoped<IAccountUseCase, AccountUseCase>();
builder.Services.AddScoped<ITransactionUseCase, TransactionUseCase>();
builder.Services.AddScoped<ILedgerEntryUseCase, LedgerEntryUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapApiRoutes();

app.Run();

