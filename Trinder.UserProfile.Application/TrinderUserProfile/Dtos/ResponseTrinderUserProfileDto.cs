using Trinder.UserProfile.Domain.Entities;

namespace Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

public class ResponseTrinderUserProfileDto
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? Bio { get; set; }

    public ICollection<ResponseFotoDto> Fotos { get; set; } = [];
    public ICollection<ResponseInterestDto> Interests { get; set; } = [];
}