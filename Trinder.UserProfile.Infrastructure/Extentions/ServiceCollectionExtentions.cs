using Azure.Storage.Blobs;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Trinder.UserProfile.Domain.Interfaces;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;
using Trinder.UserProfile.Infrastructure.Persistence;
using Trinder.UserProfile.Infrastructure.Repositories;
using Trinder.UserProfile.Infrastructure.Seeders;
using Trinder.UserProfile.Infrastructure.Storages;

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
        services.AddScoped<IFotosRepository, FotosRepository>();

        //var appAssembly = typeof(ServiceCollectionExtentions).Assembly;
        //if (appAssembly is not null)
        //{
        //    services.AddValidatorsFromAssemblies(new List<Assembly>() { appAssembly }).AddFluentValidationAutoValidation();
        //}

        //Azure Blob config
        var blobConnectionString = configuration.GetConnectionString("BlobStorage");
        services.AddSingleton(x => new BlobServiceClient(blobConnectionString));
        services.AddSingleton<IBlobStorageService, BlobStorageService>();
    }
}
