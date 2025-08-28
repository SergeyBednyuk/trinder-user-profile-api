using MediatR;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileInterests;

public record AddUserProfileInterestsCommand (int UserProfileId, ICollection<int> InterestsInts) : IRequest<ResponseTrinderFullUserProfileDto> { }
