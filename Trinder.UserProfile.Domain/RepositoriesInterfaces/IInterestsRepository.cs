using Trinder.UserProfile.Domain.Entities;

namespace Trinder.UserProfile.Domain.RepositoriesInterfaces;

public interface IInterestsRepository
{
    //Queries
    Task<IReadOnlyCollection<Interest>> GetInterestsAsync();
    Task<IReadOnlyCollection<Interest>> GetByIdsAsync(IEnumerable<int> ids);
}
