namespace Trinder.UserProfile.Application.TrinderUserProfile.Commands.AddUserProfileInterests;

public record AddUserProfileInterestsCommand (int UserProfileId, ICollection<int> InterestsInts) { }
