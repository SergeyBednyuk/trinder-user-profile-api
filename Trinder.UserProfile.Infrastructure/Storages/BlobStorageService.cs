using Azure.Storage.Blobs;
using Trinder.UserProfile.Domain.Interfaces;

namespace Trinder.UserProfile.Infrastructure.Storages;

public class BlobStorageService : IBlobStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobStorageService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }

    public async Task<string> UploadToBlobStorage(Stream data, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("fotos");
        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(data);

        var blobUri = blobClient.Uri.ToString();
        return blobUri;
    }
}
