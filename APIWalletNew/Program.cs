using APIWalletNew;
using APIWalletNew.Data;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

// builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//     .AddNegotiate();
//
// builder.Services.AddAuthorization(options =>
//  {
//      // By default, all incoming requests will be authorized according to the default policy.
//      options.FallbackPolicy = options.DefaultPolicy;
//  });

var app = builder.Build();

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