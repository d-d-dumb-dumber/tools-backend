using Domain.Constants;
using Domain.UnitOfWork;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Modules.ServiceCollectionExtensions;

internal static class SqlExtensions
{
    public static IServiceCollection AddSQLServer(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString(ConfigurationConstants.TOOLS_BD_CONNECTION_STRING);
        
        services.AddDbContext<ToolsContext>(
            options =>
            {
                options.UseSqlServer(connectionString, option => option.MigrationsAssembly(nameof(Infrastructure)));
                options.EnableSensitiveDataLogging();
            });
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
