using MediatR;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetAllFullUserProfile;

public record GetAllFullUserProfileCommand : IRequest<IReadOnlyCollection<ResponseTrinderFullUserProfileDto>> { }
