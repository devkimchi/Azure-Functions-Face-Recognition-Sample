using System;
using System.IO;
using System.Threading.Tasks;

namespace FaceApiSample.FunctionApp.Models
{
    /// <summary>
    /// This represents the entity for the embedded request from the front-end.
    /// </summary>
    public class EmbeddedRequest
    {
        private readonly Stream _payload;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedRequest"/> class.
        /// </summary>
        /// <param name="payload"><see cref="Stream"/> instance.</param>
        public EmbeddedRequest(Stream payload)
        {
            this._payload = payload;
        }

        /// <summary>
        /// Gets or sets the content type of the embedded request payload.
        /// </summary>
        public virtual string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the embedded image data.
        /// </summary>
        public virtual byte[] Body { get; set; }

        /// <summary>
        /// Gets or sets the filename of the embedded image data.
        /// </summary>
        public virtual string Filename { get; set; }

        /// <summary>
        /// Processes the embedded request payload for further processing.
        /// </summary>
        /// <param name="personGroup">Name of the person group.</param>
        /// <returns>Returns the <see cref="EmbeddedRequest"/> instance.</returns>
        public async Task<EmbeddedRequest> ProcessAsync(string personGroup)
        {
            if (string.IsNullOrWhiteSpace(personGroup))
            {
                throw new ArgumentNullException(nameof(personGroup));
            }

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

            var filename = $"{personGroup}/{Guid.NewGuid().ToString()}.png";
            this.Filename = filename;

            return this;
        }
    }
}
