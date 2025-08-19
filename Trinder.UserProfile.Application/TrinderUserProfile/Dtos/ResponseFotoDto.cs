namespace Trinder.UserProfile.Application.TrinderUserProfile.Dtos;

public class ResponseFotoDto
{
    public string Name { get; set; } = default!;
    public string Url { get; set; } = default!;
    public bool IsItProfileFoto { get; set; }
}
