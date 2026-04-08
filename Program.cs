using TorneoServiciosIAM.Api;
using TorneoServiciosIAM.Application.DTOs;
using TorneoServiciosIAM.Application.Interfaces;
using TorneoServiciosIAM.Infrastructure.Persistence;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(IAMEndpoints).Assembly));

builder.Services.AddScoped<RespuestaValidacionUsuarioDTO>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<ISesionesRepository, SesionesRepository>();
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString");
    return new MongoClient(connectionString);
});

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    var dbName = builder.Configuration.GetValue<string>("MongoDbSettings:DatabaseName");
    return client.GetDatabase(dbName);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapIAMEndpoints();

app.Run();
