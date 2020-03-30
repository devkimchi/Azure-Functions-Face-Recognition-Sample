using System;

namespace FaceApiSample.FunctionApp.Configs
{
    public class BlobSettings
    {
        private const string ContainerNameKey = "Blob__Container";
        private const string PersonGroupNameKey = "Blob__PersonGroup";

        public virtual string Container { get; set; } = Environment.GetEnvironmentVariable(ContainerNameKey);
        public virtual string PersonGroup { get; set; } = Environment.GetEnvironmentVariable(PersonGroupNameKey);
    }
}
