using MediatR;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetUserProfileById;

public class GetUserProfileByIdQuery(int id) : IRequest<ResponseTrinderUserProfileDto>
{
    public int UserProfileId { get; } = id;
}
