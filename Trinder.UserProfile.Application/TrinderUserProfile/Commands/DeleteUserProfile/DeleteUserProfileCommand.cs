using MediatR;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.DeleteUserProfile;

public class DeleteUserProfileCommand(int userProfileId) : IRequest
{
    public int UserProfileId { get; } = userProfileId;
}
