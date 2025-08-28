using Microsoft.EntityFrameworkCore;
using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;
using Trinder.UserProfile.Infrastructure.Persistence;

namespace Trinder.UserProfile.Infrastructure.Repositories;

public class InterestsRepository(UserProfilesDbContext DbContext) : IInterestsRepository
{
    #region Commands

    public async Task<IReadOnlyCollection<Interest>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default)
    {
        var interests = await DbContext.Interests.AsNoTracking()
                                                 .Where(x => ids.Contains(x.Id))
                                                 .ToListAsync(cancellationToken);

        return interests;
    }

    public async Task<IReadOnlyCollection<Interest>> GetInterestsAsync(CancellationToken cancellationToken = default)
    {
        var interests = await DbContext.Interests.AsNoTracking().ToListAsync(cancellationToken);
        return interests;
    }

    #endregion

    #region Queries

    public async Task<bool> AddNewInterestsToUserProfileAsync(int userProfileId, ICollection<int> ids, CancellationToken cancellationToken = default)
    {
        List<UserProfileInterest> userProfileInterests = [];
        foreach (int id in ids) 
        {
            userProfileInterests.Add(new UserProfileInterest 
            {
                UserProfileId = userProfileId,
                InterestId = id
            });
        }

        DbContext.ProfileInterests.AddRange(userProfileInterests);
        var result = await DbContext.SaveChangesAsync(cancellationToken);

        return result == ids.Distinct().Count();
    }

    #endregion
}
