namespace FaceApiSample.FunctionApp.Configs
{
    /// <summary>
    /// This represents the app settings entity.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the <see cref="BlobSettings"/> instance.
        /// </summary>
        public virtual BlobSettings Blob { get; set; } = new BlobSettings();

        /// <summary>
        /// Gets or sets the <see cref="TableSettings"/> instance.
        /// </summary>
        public virtual TableSettings Table { get; set; } = new TableSettings();

        /// <summary>
        /// Gets or sets the <see cref="FaceSettings"/> instance.
        /// </summary>
        public virtual FaceSettings Face { get; set; } = new FaceSettings();
    }
}
