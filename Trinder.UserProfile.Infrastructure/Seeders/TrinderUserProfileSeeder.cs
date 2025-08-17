
using Microsoft.EntityFrameworkCore;
using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Infrastructure.Persistence;

namespace Trinder.UserProfile.Infrastructure.Seeders;

public class TrinderUserProfileSeeder(UserProfilesDbContext dbContext) : ITrinderUserProfileSeeder
{
    public async Task Seed()
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Interests.Any())
            {
                var interests = GetInterests();
                dbContext.Interests.AddRange(interests);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.TrinderUserProfiles.Any())
            {
                var userProfile = GetTrinderUserProfiles();
                dbContext.TrinderUserProfiles.AddRange(userProfile);

                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IReadOnlyCollection<Interest> GetInterests()
    {
        var interests = new List<Interest>
        {
            new Interest
            {
                Name = "GYM"
            },
            new Interest
            {
                Name = "Music"
            },
            new Interest
            {
                Name = "Cooking"
            },
            new Interest
            {
                Name = "Nature"
            },
            new Interest
            {
                Name = "Art"
            },
            new Interest
            {
                Name = "Music"
            },
            new Interest
            {
                Name = "Cars"
            }
        };

        return interests;
    }

    private IReadOnlyCollection<TrinderUserProfile> GetTrinderUserProfiles()
    {
        var userProfiles = new List<TrinderUserProfile>
        {
            new TrinderUserProfile
            {
                UserName = "Admin",
                UserEmail = "admin@test.com",
                Bio = "Admin 123"
            }
        };

        return userProfiles;
    }
}
