using APIWalletNew.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIWalletNew;

public static class DependencyInjection
{
    public static IServiceCollection AddWalletNew(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationBdContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        return services;
    }
}