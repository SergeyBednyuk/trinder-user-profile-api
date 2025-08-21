using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Application.TrinderUserProfile.Commands.UpdateUserProfile;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.UpdateUserProfileInfo;

public class UpdateUserProfileInfoCommandHandler(ILogger<UpdateUserProfileInfoCommandHandler> logger, 
    IUserProfilesRepository userProfilesRepository) : IRequestHandler<UpdateUserProfileInfoCommand, bool>
{
    public async Task<bool> Handle(UpdateUserProfileInfoCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating user profile with UserName: {UserName} and Email: {Email}",
                        request.UserName, request.Email);

        var user = await userProfilesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (user is null) throw new Exception($"User profile with {request.Id} id doesn't exists");

        var userProfileToBeUpdated = new Domain.Entities.TrinderUserProfile
        {
            Id = request.Id,
            UserEmail = request.Email,
            UserName = request.UserName,
            Bio = request.Bio
        };

        var result = await userProfilesRepository.UpdateAsync(userProfileToBeUpdated, cancellationToken);

        return result;
    }
}
