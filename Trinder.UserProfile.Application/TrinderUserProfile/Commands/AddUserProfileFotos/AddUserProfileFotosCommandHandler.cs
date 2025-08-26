using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.Exceptions;
using Trinder.UserProfile.Domain.Interfaces;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileFotos;

public class AddUserProfileFotosCommandHandler(ILogger<AddUserProfileFotosCommandHandler> logger,
    IUserProfilesRepository userProfilesRepository,
    IBlobStorageService blobStorageService,
    IFotosRepository fotosRepository) : IRequestHandler<AddUserProfileFotosCommand, ResponseTrinderFullUserProfileDto>
{
    public async Task<ResponseTrinderFullUserProfileDto> Handle(AddUserProfileFotosCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Addeding fotos to user profile for UserNameId: {UserProfileId}", request.UserProfileId);

        var userProfile = await userProfilesRepository.GetByIdAsync(request.UserProfileId, cancellationToken);
        if (userProfile is null) throw new NotFoundException(nameof(TrinderUserProfile), request.UserProfileId.ToString());

        List<Foto> newFotos = [];

        foreach (var foto in request.Fotos)
        {
            var fotoUrl = await blobStorageService.UploadToBlobStorage(foto.OpenReadStream(), foto.Name);
            var newfoto = new Foto
            {
                UserProfile = userProfile,
                UserProfileId = userProfile.Id,
                Name = foto.Name,
                UploadedAt = DateTime.UtcNow,
                Url = fotoUrl
            };
        }

        var result = await fotosRepository.AddFotosAsync(newFotos, cancellationToken);
        if (result != newFotos.Count) throw new ProblemDuringSavingException("Fotos adding", nameof(Foto));


    }
}
