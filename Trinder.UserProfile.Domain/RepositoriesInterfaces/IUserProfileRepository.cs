using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.Helpers;

namespace Trinder.UserProfile.Domain.RepositoriesInterfaces;

public interface IUserProfileRepository
{
    Task<IReadOnlyCollection<TrinderUserProfile>> GetAllAsync(CancellationToken cancellationToken = default);
    //TODO
    //Task<IReadOnlyCollection<TrinderUserProfile>> GetAllFilteringAsync(UserProfilesQueryParameters queryParameters);
    Task<TrinderUserProfile?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TrinderUserProfile> AddAsync(TrinderUserProfile user, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(TrinderUserProfile user, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
