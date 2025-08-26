using MediatR;
using Microsoft.AspNetCore.Http;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileFotos;

public class AddUserProfileFotosCommand(int userProfileId, ICollection<IFormFile> fotos) : IRequest<ResponseTrinderFullUserProfileDto>
{
    public int UserProfileId { get; } = userProfileId;
    public ICollection<IFormFile> Fotos { get; } = fotos;
}
