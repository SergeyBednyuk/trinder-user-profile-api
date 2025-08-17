using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;
using Trinder.UserProfile.Infrastructure.Persistence;
using Trinder.UserProfile.Infrastructure.Repositories;
using Trinder.UserProfile.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extentions;

public static class ServiceCollectionExtentions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("UserProfilesDb");
        services.AddDbContext<UserProfilesDbContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<ITrinderUserProfileSeeder, TrinderUserProfileSeeder>();
        services.AddScoped<IUserProfilesRepository, UserProfilesRepository>();
    }
}
