using MediatR;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.CreateUserProfile;

public class CreateUserProfileCommand : IRequest<int>
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Bio { get; set; }

    //TODO
    public string FotoName { get; set; } = default!;
    public string FotoUrl { get; set; } = default!;
    public bool IsItProfileFoto { get; set; }
    //TODO
    public string Name { get; set; } = default!;
}
