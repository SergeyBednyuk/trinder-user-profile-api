using Microsoft.EntityFrameworkCore;
using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;
using Trinder.UserProfile.Infrastructure.Persistence;

namespace Trinder.UserProfile.Infrastructure.Repositories;

public class UserProfilesRepository(UserProfilesDbContext dbContext) : IUserProfilesRepository
{
    public async Task<TrinderUserProfile> AddAsync(TrinderUserProfile user, CancellationToken cancellationToken = default)
    {
        dbContext.TrinderUserProfiles.Add(user);
        await dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var userProfileToDelete = await dbContext.TrinderUserProfiles.FindAsync(id);

        if (userProfileToDelete is null)
            return false;

        dbContext.TrinderUserProfiles.Remove(userProfileToDelete);
        var result = await dbContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }

    public async Task<IReadOnlyCollection<TrinderUserProfile>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var userProfiles = await dbContext.TrinderUserProfiles.Include(x => x.Fotos)
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

    public async Task<bool> UpdateAsync(TrinderUserProfile user, CancellationToken cancellationToken = default)
    {
        //TODO update the method to reduce amount of updated properties?
        dbContext.TrinderUserProfiles.Update(user);
        var result = await dbContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
