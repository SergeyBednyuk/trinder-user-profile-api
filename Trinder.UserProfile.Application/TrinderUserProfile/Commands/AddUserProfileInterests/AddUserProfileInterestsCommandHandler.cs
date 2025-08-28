using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Domain.Exceptions;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileInterests;

public class AddUserProfileInterestsCommandHandler(ILogger<AddUserProfileInterestsCommandHandler> logger, 
    IMapper mapper, 
    IUserProfilesRepository userProfilesRepository, 
    IInterestsRepository interestsRepository) : IRequestHandler<AddUserProfileInterestsCommand, ResponseTrinderFullUserProfileDto>
{
    public async Task<ResponseTrinderFullUserProfileDto> Handle(AddUserProfileInterestsCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Addeding interests to user profile for UserNameId: {UserProfileId}", request.UserProfileId);

        var userProfile = await userProfilesRepository.FindByIdAsync(request.UserProfileId);
        if (userProfile is null) throw new NotFoundException(nameof(TrinderUserProfile), request.UserProfileId.ToString());

        var interests = await interestsRepository.GetByIdsAsync(request.InterestsInts, cancellationToken);
        if (interests is not null) userProfile.Interests = interests.ToList();

        var result = await userProfilesRepository.UpdateAsync(userProfile);

        return mapper.Map<ResponseTrinderFullUserProfileDto>(userProfile);
    }
}
