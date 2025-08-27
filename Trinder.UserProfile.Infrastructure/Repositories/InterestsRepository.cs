using Microsoft.EntityFrameworkCore;
using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;
using Trinder.UserProfile.Infrastructure.Persistence;

namespace Trinder.UserProfile.Infrastructure.Repositories;

public class InterestsRepository(UserProfilesDbContext DbContext) : IInterestsRepository
{
    public async Task<IReadOnlyCollection<Interest>> GetByIdsAsync(IEnumerable<int> ids)
    {
        var interests = await DbContext.Interests.AsNoTracking()
                                           .Where(x => ids.Contains(x.Id))
                                           .ToListAsync();

        return interests;
    }

    public Task<IReadOnlyCollection<Interest>> GetInterestsAsync()
    {
        throw new NotImplementedException();
    }
}
