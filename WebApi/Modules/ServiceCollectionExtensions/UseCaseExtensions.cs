using System.Diagnostics.CodeAnalysis;
using Application.UseCases.PostUser;

namespace WebApi.Modules.ServiceCollectionExtensions;

[ExcludeFromCodeCoverage]
public static class UseCasesExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IPostUser, PostUser>();

        return services;
    }
}