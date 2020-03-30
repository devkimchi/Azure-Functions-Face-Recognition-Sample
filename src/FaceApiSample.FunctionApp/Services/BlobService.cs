using System;
using System.Threading.Tasks;

using FaceApiSample.FunctionApp.Configs;
using FaceApiSample.FunctionApp.Extensions;

using Microsoft.WindowsAzure.Storage.Blob;

namespace FaceApiSample.FunctionApp.Services
{
    public interface IBlobService
    {
        Task<Uri> UploadAsync(byte[] bytes, string filename, string contentType);
    }

    public class BlobService : IBlobService
    {
        private readonly AppSettings _settings;
        private readonly CloudBlobClient _client;

        public BlobService(AppSettings settings, CloudBlobClient client)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<Uri> UploadAsync(byte[] bytes, string filename, string contentType)
        {
            var containerName = this._settings.Blob.Container;
            var container = this._client.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync().ConfigureAwait(false);

            var blob = await container.GetBlockBlobReference(filename)
                                      .SetContentType(contentType)
                                      .UploadByteArrayAsync(bytes, 0, bytes.Length)
                                      .ConfigureAwait(false);

            return blob.Uri;
        }
    }
}
