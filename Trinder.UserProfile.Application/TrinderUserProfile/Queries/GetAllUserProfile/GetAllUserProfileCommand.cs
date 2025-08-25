using MediatR;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetAllUserProfile;

public record GetAllUserProfileCommand : IRequest<IReadOnlyCollection<ResponseTrinderUserProfileDto>> {}
