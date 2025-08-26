namespace Trinder.UserProfile.Domain.Interfaces;

public interface IBlobStorageService
{
    Task<string> UploadToBlobStorage(Stream data, string fileName);
}
