using MediatR;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.UpdateUserProfile;

public class UpdateUserProfileInfoCommand(int id, string userName, string email, string? bio = null) : IRequest<bool>
{
    public int Id { get; } = id;
    public string UserName { get; } = userName;
    public string Email { get; } = email;
    public string? Bio { get; } = bio;
}
