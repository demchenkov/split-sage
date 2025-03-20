using Microsoft.EntityFrameworkCore;
using SplitSage.Bot.Telegram.Common.Application;

namespace SplitSage.Bot.Telegram.Common.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SplitSageDb");
        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        
        return services;
    }
}