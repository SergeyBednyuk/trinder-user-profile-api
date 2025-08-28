using Trinder.UserProfile.Domain.Entities;

namespace Trinder.UserProfile.Domain.RepositoriesInterfaces;

public interface IInterestsRepository
{
    //Queries
    Task<IReadOnlyCollection<Interest>> GetInterestsAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Interest>> GetByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default);
    //Commands
    Task<bool> AddNewInterestsToUserProfileAsync(int userProfileId, ICollection<int> ids, CancellationToken cancellationToken = default);
}
