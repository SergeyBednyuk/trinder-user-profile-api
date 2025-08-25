namespace Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

public class ResponseTrinderFullUserProfileDto 
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Bio { get; set; }

    public ICollection<ResponseFotoDto> Fotos { get; set; } = [];
    public ICollection<ResponseInterestDto> Interests { get; set; } = [];

    public bool IsDeleted { get; set; }
    public DateTime? DeletedAtUtc { get; set; }
}