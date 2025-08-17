using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Infrastructure.Repositories;

public class UserProfilesRepository : IUserProfilesRepository
{
    public Task<TrinderUserProfile> AddAsync(TrinderUserProfile user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<TrinderUserProfile>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TrinderUserProfile?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(TrinderUserProfile user, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
