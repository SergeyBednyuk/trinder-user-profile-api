using MediatR;
using Microsoft.Extensions.Logging;
using Trinder.UserProfile.Domain.Exceptions;
using Trinder.UserProfile.Domain.RepositoriesInterfaces;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.DeleteUserProfile;

public class DeleteUserProfileCommandHandler(ILogger<DeleteUserProfileCommandHandler> logger,
    IUserProfilesRepository userProfilesRepository) : IRequestHandler<DeleteUserProfileCommand>
{
    public async Task Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting user profile for id: {UserProfileId}", request.UserProfileId);
        var userProfile = await userProfilesRepository.GetByIdAsync(request.UserProfileId);
        if (userProfile is null) throw new NotFoundException(nameof(TrinderUserProfile), request.UserProfileId.ToString());

        var result = await userProfilesRepository.DeleteAsync(userProfile, cancellationToken);
        if (!result) throw new CantBePerformedException("Deleting", nameof(TrinderUserProfile));
    }
}
