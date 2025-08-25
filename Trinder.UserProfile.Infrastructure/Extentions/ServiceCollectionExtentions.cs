using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;
using Trinder.UserProfile.Infrastructure.Persistence;
using Trinder.UserProfile.Infrastructure.Repositories;
using Trinder.UserProfile.Infrastructure.Seeders;

namespace Trinder.UserProfile.Infrastructure.Extentions;

public static class ServiceCollectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<SoftDeleteInterceptor>();

        var connectionString = configuration.GetConnectionString("UserProfilesDb");
        services.AddDbContext<UserProfilesDbContext>((sp,opt) => opt.UseNpgsql(connectionString).AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>()));

        services.AddScoped<ITrinderUserProfileSeeder, TrinderUserProfileSeeder>();
        services.AddScoped<IUserProfilesRepository, UserProfilesRepository>();
    }
}
