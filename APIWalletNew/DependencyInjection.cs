using APIWalletNew.Data;
using APIWalletNew.Data.Respositories;
using APIWalletNew.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace APIWalletNew;

public static class DependencyInjection
{
    public static IServiceCollection AddWalletNew(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationBdContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IWalletRepository, WalletRepository>();
        
        return services;
    }
}