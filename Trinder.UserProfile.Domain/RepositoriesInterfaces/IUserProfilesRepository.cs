using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.Helpers;

namespace Trinder.UserProfile.Domain.RepositoriesInterfaces;

public interface IUserProfilesRepository
{
    Task<IReadOnlyCollection<TrinderUserProfile>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TrinderUserProfile>> GetAllWithSummariesAsync(CancellationToken cancellationToken = default);
    //TODO
    //Task<IReadOnlyCollection<TrinderUserProfile>> GetAllFilteringAsync(UserProfilesQueryParameters queryParameters);
    Task<TrinderUserProfile?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TrinderUserProfile?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<TrinderUserProfile?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);
    Task<TrinderUserProfile> AddAsync(TrinderUserProfile userProfile, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(TrinderUserProfile userProfile, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
