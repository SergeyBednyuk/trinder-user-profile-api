using MediatR;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileFotos;

public class AddUserProfileFotosCommands : IRequest<ResponseTrinderFullUserProfileDto>
{
    public int UserProfileId { get; set; }
}
