namespace Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

public class ResponseTrinderUserProfileDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Bio { get; set; }
}
