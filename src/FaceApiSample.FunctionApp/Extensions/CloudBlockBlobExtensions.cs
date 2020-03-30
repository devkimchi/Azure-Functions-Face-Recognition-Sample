using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage.Blob;

namespace FaceApiSample.FunctionApp.Extensions
{
    public static class CloudBlockBlobExtensions
    {
        public static CloudBlockBlob SetContentType(this CloudBlockBlob instance, string contentType)
        {
            instance.Properties.ContentType = contentType;

            return instance;
        }

        public async static Task<CloudBlockBlob> UploadByteArrayAsync(this CloudBlockBlob instance, byte[] bytes, int index, int count)
        {
            await instance.UploadFromByteArrayAsync(bytes, index, count).ConfigureAwait(false);

            return instance;
        }
    }
}
