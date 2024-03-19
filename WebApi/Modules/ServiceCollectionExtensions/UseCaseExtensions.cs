using Application.UseCases.PostUser;

namespace WebApi.Modules.ServiceCollectionExtensions;

public static class UseCasesExtensions
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IPostUser, PostUser>();

        return services;
    }
}