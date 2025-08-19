using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Trinder.UserProfile.Application.TrinderUserProfile.Utils;

namespace Trinder.UserProfile.Application.Extentions;

public static class ServiceCollectionExtentions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var appAssembly = typeof(ServiceCollectionExtentions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(appAssembly));

        services.AddAutoMapper(cfg => { }, typeof(TrinderUserProfileProfile), typeof(InterestProfile), typeof(FotoProfile));
    }
}
