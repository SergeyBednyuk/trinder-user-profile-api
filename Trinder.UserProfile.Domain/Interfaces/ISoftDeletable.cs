namespace Trinder.UserProfile.Domain.Interfaces;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
    public DateTime? DeletedAtUtc { get; set; }
}
