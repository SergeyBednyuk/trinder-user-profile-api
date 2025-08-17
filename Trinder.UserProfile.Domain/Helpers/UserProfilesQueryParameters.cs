namespace Trinder.UserProfile.Domain.Helpers;

public class UserProfilesQueryParameters
{
    public string? SearchPhrase { get; set; }
    public string? SortBy { get; set; }
    public bool SortAscending { get; set; } = true;
    public int? PageSize { get; set; }
    public int? PageNumber { get; set; }
}
