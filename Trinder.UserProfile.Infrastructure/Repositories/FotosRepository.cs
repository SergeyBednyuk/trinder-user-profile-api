using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;
using Trinder.UserProfile.Infrastructure.Persistence;

namespace Trinder.UserProfile.Infrastructure.Repositories;

public class FotosRepository(UserProfilesDbContext dbContext) : IFotosRepository
{
    public async Task<Foto> AddFotoAsync(Foto newFoto, CancellationToken cancellationToken)
    {
        dbContext.Fotos.Add(newFoto);
        await dbContext.SaveChangesAsync();

        return newFoto;
    }

    public Task<IReadOnlyCollection<Foto>> AddFotosAsync(ICollection<Foto> newFotos, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFotoAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Foto?> GetFotoByIdAsync(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Foto>> GetFotosAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Foto>> GetFotosByUserProfileIdAsync(int userProfileId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateFotoAsync(Foto updatedFoto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    async Task<bool> IFotosRepository.AddFotosAsync(ICollection<Foto> newFotos, CancellationToken cancellationToken)
    {
        dbContext.Fotos.AddRange(newFotos);
        var result = await dbContext.SaveChangesAsync();

        return result > 0;
    }
}
