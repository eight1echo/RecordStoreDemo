using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.AspNetCore.Components.Forms;

namespace RecordStoreDemo.External.Azure;
public class AzureStorageService(AzureKeyVaultService _keyVault)
{
    public async Task<Stream> ReadFromStorage(string containerName, string fileName)
    {
        string? connectionString = await _keyVault.GetSecret("AzureStorageConnectionString");

        var container = new BlobContainerClient(connectionString, containerName);
        var blobClient = container.GetBlockBlobClient(fileName);
        BlobDownloadInfo download = blobClient.Download();

        return download.Content;
    }

    public async Task UploadToStorage(string containerName, string fileName, IBrowserFile file)
    {
        string? connectionString = await _keyVault.GetSecret("AzureStorageConnectionString");

        var container = new BlobContainerClient(connectionString, containerName);
        var createResponse = await container.CreateIfNotExistsAsync();

        if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            await container.SetAccessPolicyAsync(PublicAccessType.Blob);

        var blob = container.GetBlobClient(fileName);

        await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

        await blob.UploadAsync(file.OpenReadStream(file.Size));
    }
}