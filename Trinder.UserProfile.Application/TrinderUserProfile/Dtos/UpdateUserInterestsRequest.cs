namespace Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

public class UpdateUserInterestsRequest
{
    public ICollection<int> InterestIds { get; set; } = default!;
}
