using System.Text;
using APIWalletNew;
using APIWalletNew.Data;
using APIWalletNew.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

Console.WriteLine(
    builder.Configuration.GetConnectionString("DefaultConnection")
);

Console.WriteLine(builder.Environment.EnvironmentName);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWalletNew(builder.Configuration);
builder.Services.AddControllers();

// builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//     .AddNegotiate();
//
// builder.Services.AddAuthorization(options =>
//  {
//      // By default, all incoming requests will be authorized according to the default policy.
//      options.FallbackPolicy = options.DefaultPolicy;
//  });

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Bearer", configureOptions =>
        configureOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
        }
    );

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

app.MapControllers(); // enable traditional controllers without use a minimal APIs

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.MapGet("/viewConnectionStatus", async ([FromServices] ApplicationBdContext context) =>
    {
        try
        {
            var connection = await context.Database.CanConnectAsync();
            return connection
                ? Results.Ok("Database Connection Successfully")
                : Results.Problem("Cannot connect with database");
        }
        catch (Exception e)
        {
            return Results.Problem(title: "Error", detail: e.Message);
        }
    });
}

app.Run();