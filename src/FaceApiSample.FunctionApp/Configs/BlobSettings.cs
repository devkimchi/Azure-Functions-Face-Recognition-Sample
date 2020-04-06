using System;

namespace FaceApiSample.FunctionApp.Configs
{
    /// <summary>
    /// This represents the settings entity for Azure Blob Storage.
    /// </summary>
    public class BlobSettings
    {
        private const string SasTokenKey = "Blob__SasToken";
        private const string ContainerNameKey = "Blob__Container";
        private const string PersonGroupNameKey = "Blob__PersonGroup";
        private const string NumberOfPhotosKey = "Blob__NumberOfPhotos";

        /// <summary>
        /// Gets or sets the SAS token of the blob container.
        /// </summary>
        /// <returns></returns>
        public virtual string SasToken { get; set; } = Environment.GetEnvironmentVariable(SasTokenKey);

        /// <summary>
        /// Gets or sets the blob container name.
        /// </summary>
        public virtual string Container { get; set; } = Environment.GetEnvironmentVariable(ContainerNameKey);

        /// <summary>
        /// Gets or sets the person group name.
        /// </summary>
        public virtual string PersonGroup { get; set; } = Environment.GetEnvironmentVariable(PersonGroupNameKey);

        /// <summary>
        /// Gets or sets the number of photos to check.
        /// </summary>
        public virtual int NumberOfPhotos { get; set; } = Convert.ToInt32(Environment.GetEnvironmentVariable(NumberOfPhotosKey));
    }
}
