using Trinder.UserProfile.Domain.Entities;

namespace Trinder.UserProfile.Domain.RepositoriesInterfaces;

public interface IFotosRepository
{
    Task<Foto> AddFotoAsync(Foto newFoto, CancellationToken cancellationToken);
    Task<bool> AddFotosAsync(ICollection<Foto> newFotos, CancellationToken cancellationToken);
    Task<bool> UpdateFotoAsync(Foto updatedFoto, CancellationToken cancellationToken);
    Task<bool> DeleteFotoAsync(string id);
    Task<IReadOnlyCollection<Foto>> GetFotosAsync(CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Foto>> GetFotosByUserProfileIdAsync(int userProfileId, CancellationToken cancellationToken);
    Task<Foto?> GetFotoByIdAsync(string id, CancellationToken cancellationToken);
}
