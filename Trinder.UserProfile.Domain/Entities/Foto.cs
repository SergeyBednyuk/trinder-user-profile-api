namespace Trinder.UserProfile.Domain.Entities;

public class Foto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
    public bool IsItProfileFoto { get; set; }
    public DateTime UploadedAt { get; set; }

    public int UserProfileId { get; set; }
    public TrinderUserProfile UserProfile { get; set; } = default!;
}
