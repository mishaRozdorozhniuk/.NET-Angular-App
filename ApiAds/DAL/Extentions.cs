using System;
using Microsoft.EntityFrameworkCore;

namespace ApiAds.DAL;

public static class Extentions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AdsContext>(options =>
        {
            var connectionString = configuration["ConnectionString"];
            options.UseNpgsql(connectionString);
        });

        services.AddHostedService<DatabaseInitializer<AdsContext>>();

        return services;
    }
}