namespace FaceApiSample.FunctionApp.Configs
{
    public class AppSettings
    {
        public virtual BlobSettings Blob { get; set; } = new BlobSettings();
    }
}
