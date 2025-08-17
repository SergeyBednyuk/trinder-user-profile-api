namespace Trinder.UserProfile.Domain.Entities;

public class TrinderUserProfile
{
    public int Id { get; set; }
    public string UserName { get; set; } = default!;
    public string UserEmail { get; set; } = default!;
    public string? Bio { get; set; }

    public ICollection<Foto> Fotos { get; set; } = [];
    public ICollection<Interest> Interests { get; set; } = [];
}
