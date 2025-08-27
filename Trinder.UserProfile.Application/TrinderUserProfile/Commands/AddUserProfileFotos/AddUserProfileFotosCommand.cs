using MediatR;
using Microsoft.AspNetCore.Http;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileFotos;

public class AddUserProfileFotosCommand(int userProfileId, ICollection<CreateFotoDto> fotos) : IRequest<ResponseTrinderFullUserProfileDto>
{
    public int UserProfileId { get; } = userProfileId;
    public ICollection<CreateFotoDto> Fotos { get; } = fotos;
}
