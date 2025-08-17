namespace Trinder.UserProfile.Domain.Entities;

public class Interest
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public ICollection<UserProfile> UserProfiles { get; set; } = [];
}
