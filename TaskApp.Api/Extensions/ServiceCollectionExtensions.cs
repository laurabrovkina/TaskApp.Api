using TaskApp.Api.Persistence;
using TaskApp.Api.Services;

namespace TaskApp.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITaskService, TaskService>();

        return services;
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IDbConnectionFactory>(_ => 
            new NpgsqlConnectionFactory(
                DbConstants.DefaultConnectionStringPath));

        services.AddScoped<TaskRepository>();

        return services;
    }
}