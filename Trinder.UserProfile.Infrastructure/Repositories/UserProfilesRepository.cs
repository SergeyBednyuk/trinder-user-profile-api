using Microsoft.EntityFrameworkCore;
using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;
using Trinder.UserProfile.Infrastructure.Persistence;

namespace Trinder.UserProfile.Infrastructure.Repositories;

public class UserProfilesRepository(UserProfilesDbContext dbContext) : IUserProfilesRepository
{
    public async Task<TrinderUserProfile> AddAsync(TrinderUserProfile userProfile, CancellationToken cancellationToken = default)
    {
        dbContext.TrinderUserProfiles.Add(userProfile);
        await dbContext.SaveChangesAsync(cancellationToken);

        return userProfile;
    }

    public async Task<bool> DeleteAsync(TrinderUserProfile userProfile, CancellationToken cancellationToken = default)
    {
        dbContext.TrinderUserProfiles.Remove(userProfile);
        var result = await dbContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }

    public async Task<IReadOnlyCollection<TrinderUserProfile>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var userProfiles = await dbContext.TrinderUserProfiles.AsNoTracking()
                                                              .ToListAsync(cancellationToken);
        return userProfiles;
    }

    public async Task<IReadOnlyCollection<TrinderUserProfile>> GetAllFullAsync(CancellationToken cancellationToken = default)
    {
        var userProfiles = await dbContext.TrinderUserProfiles.IgnoreQueryFilters()
                                                              .Include(x => x.Fotos)
                                                              .Include(x => x.Interests)
                                                              .AsNoTracking()
                                                              .ToListAsync(cancellationToken);

        return userProfiles;
    }

    public async Task<TrinderUserProfile?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var userProfile = await dbContext.TrinderUserProfiles.Include(x => x.Fotos)
                                                             .Include(x => x.Interests)
                                                             .AsNoTracking()
                                                             .FirstOrDefaultAsync(x => x.UserEmail == email, cancellationToken);

        return userProfile;
    }

    public async Task<TrinderUserProfile?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var userProfile = await dbContext.TrinderUserProfiles.Include(x => x.Fotos)
                                                             .Include(x => x.Interests)
                                                             .AsNoTracking()
                                                             .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return userProfile;
    }

    public async Task<TrinderUserProfile?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        var userProfile = await dbContext.TrinderUserProfiles.Include(x => x.Fotos)
                                                             .Include(x => x.Interests)
                                                             .AsNoTracking()
                                                             .FirstOrDefaultAsync(x => x.UserName == userName, cancellationToken);

        return userProfile;
    }

    public async Task<bool> UpdateAsync(TrinderUserProfile userProfile, CancellationToken cancellationToken = default)
    {
        //TODO update the method to reduce amount of updated properties
        //no need to delete. Just for learing porpose
        //dbContext.TrinderUserProfiles.Update(user);

        var userProfileFromDb = await dbContext.TrinderUserProfiles.FindAsync(userProfile.Id);
        if (userProfileFromDb is null) return false;

        userProfileFromDb.UserName = userProfile.UserName;
        userProfileFromDb.UserEmail = userProfile.UserEmail;
        userProfileFromDb.Bio = userProfile.Bio;

        var result = await dbContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
