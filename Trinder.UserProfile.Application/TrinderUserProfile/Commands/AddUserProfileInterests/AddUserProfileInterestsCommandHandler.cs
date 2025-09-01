using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;
using Trinder.UserProfile.Domain.Exceptions;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileInterests;

public class AddUserProfileInterestsCommandHandler(ILogger<AddUserProfileInterestsCommandHandler> logger, 
    IMapper mapper, 
    IUserProfilesRepository userProfilesRepository, 
    IInterestsRepository interestsRepository,
    IValidator<AddUserProfileInterestsCommand> validator) : IRequestHandler<AddUserProfileInterestsCommand, ResponseTrinderFullUserProfileDto>
{
    public async Task<ResponseTrinderFullUserProfileDto> Handle(AddUserProfileInterestsCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Addeding interests to user profile for UserNameId: {UserProfileId}", request.UserProfileId);

        var userProfile = await userProfilesRepository.FindByIdAsync(request.UserProfileId);
        if (userProfile is null) throw new NotFoundException(nameof(TrinderUserProfile), request.UserProfileId.ToString());

        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var interests = await interestsRepository.GetByIdsAsync(request.InterestsInts, cancellationToken);

        foreach (var interest in interests)
        {
            userProfile.Interests.Add(interest);
        }

        var result = await userProfilesRepository.UpdateAsync(userProfile);

        return mapper.Map<ResponseTrinderFullUserProfileDto>(userProfile);
    }
}
