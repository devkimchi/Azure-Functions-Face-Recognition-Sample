using System;

namespace FaceApiSample.FunctionApp.Configs
{
    /// <summary>
    /// This represents the settings entity for Azure Face Service.
    /// </summary>
    public class FaceSettings
    {
        private const string FaceAuthKeyKey = "Face__AuthKey";
        private const string FaceEndpointKey = "Face__Endpoint";
        private const string ConfidenceKey = "Face__Confidence";

        /// <summary>
        /// Gets or sets the Face service authorisation key.
        /// </summary>
        public virtual string AuthKey { get; set; } = Environment.GetEnvironmentVariable(FaceAuthKeyKey);

        /// <summary>
        /// Gets or sets the Face service endpoint.
        /// </summary>
        public virtual string Endpoint { get; set; } = Environment.GetEnvironmentVariable(FaceEndpointKey);

        /// <summary>
        /// Gets or sets the acceptable confidence value.
        /// </summary>
        public virtual double Confidence { get; set; } = Convert.ToDouble(Environment.GetEnvironmentVariable(ConfidenceKey));
    }
}
