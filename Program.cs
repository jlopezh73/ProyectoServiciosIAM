using TorneoServiciosIAM.Api;
using TorneoServiciosIAM.Application.DTOs;
using TorneoServiciosIAM.Application.Interfaces;
using TorneoServiciosIAM.Infrastructure.Persistence;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(IAMEndpoints).Assembly));

builder.Services.AddScoped<RespuestaValidacionUsuarioDTO>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<ISesionesRepository, SesionesRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
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


builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Configuration;
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;        
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = config["JWTSettings:Issuer"],
            ValidAudience = config["JWTSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSettings:Key"])),
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });


builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();



app.MapIAMEndpoints();

app.Run();
