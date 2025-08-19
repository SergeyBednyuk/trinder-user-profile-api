using MediatR;
using Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Queries.GetUserProfileById;

public class GetUserProfileByIdQuery : IRequest<ResponseTrinderUserProfileDto>
{
    public int UserProfileId { get; set; }
}
