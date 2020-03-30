using System;
using System.IO;
using System.Threading.Tasks;

namespace FaceApiSample.FunctionApp.Models
{
    public class EmbeddedRequest
    {
        private readonly Stream _payload;

        public EmbeddedRequest(Stream payload)
        {
            this._payload = payload;
        }

        public virtual string ContentType { get; set; }

        public virtual byte[] Body { get; set; }

        public async Task<EmbeddedRequest> ProcessAsync()
        {
            var body = default(string);
            using (var reader = new StreamReader(this._payload))
            {
                body = await reader.ReadToEndAsync().ConfigureAwait(false);
            }

            var segments = body.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            var contentType = segments[0].Split(new[] { ":", ";" }, StringSplitOptions.RemoveEmptyEntries)[1];

            this.ContentType = contentType;

            var encoded = segments[1];
            var bytes = Convert.FromBase64String(encoded);

            this.Body = bytes;

            return this;
        }
    }
}
