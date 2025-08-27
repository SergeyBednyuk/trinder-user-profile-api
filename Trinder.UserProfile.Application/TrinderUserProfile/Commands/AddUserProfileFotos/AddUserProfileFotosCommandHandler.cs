using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Domain.Entities;
using Trinder.UserProfile.Domain.Exceptions;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileFotos;

public class AddUserProfileFotosCommandHandler(ILogger<AddUserProfileFotosCommandHandler> logger,
    IMapper mapper,
    IUserProfilesRepository userProfilesRepository,
    IFotosRepository fotosRepository) : IRequestHandler<AddUserProfileFotosCommand, ResponseTrinderFullUserProfileDto>
{
    public async Task<ResponseTrinderFullUserProfileDto> Handle(AddUserProfileFotosCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Addeding fotos to user profile for UserNameId: {UserProfileId}", request.UserProfileId);

        var userProfile = await userProfilesRepository.FindByIdAsync(request.UserProfileId, cancellationToken);
        if (userProfile is null) throw new NotFoundException(nameof(TrinderUserProfile), request.UserProfileId.ToString());

        var newFotos = mapper.Map<List<Foto>>(request.Fotos);
        foreach (var f in newFotos)
        {
            f.UserProfileId = request.UserProfileId;
        }

        var result = await fotosRepository.AddFotosAsync(newFotos, cancellationToken);
        if (!result) throw new ProblemDuringSavingException("Fotos adding", nameof(Foto));

        return mapper.Map<ResponseTrinderFullUserProfileDto>(userProfile);
    }
}
