using MediatR;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.CreateUserProfile;

public class CreateUserProfileCommand(string userName, string email, IEnumerable<CreateFotoDto>? fotos = null, IEnumerable<CreateInterestDto>? interests = null, string? bio = null) : IRequest<int>
{
    public string UserName { get; } = userName;
    public string Email { get; } = email;
    public string? Bio { get; } = bio;
    public IEnumerable<CreateFotoDto>? Fotos { get; } = fotos;
    public IEnumerable<CreateInterestDto>? Interests { get; } = interests;
}
