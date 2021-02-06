using System;

using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.OpenApi.Models;

namespace FaceApiSample.FunctionApp.Configs
{
    /// <summary>
    /// This represents the options entity for Open API configuration.
    /// </summary>
    public class OpenApiConfigurationOptions : IOpenApiConfigurationOptions
    {
        /// <inheritdoc />
        public OpenApiInfo Info { get; set; } = new OpenApiInfo()
        {
            Version = "3.0.0",
            Title = "Face Identification Sample on Azure Functions",
            Description = "A sample API that runs on Azure Functions v3 using Open API specification.",
            TermsOfService = new Uri("https://github.com/devkimchi/Azure-Functions-Face-Recognition-Sample"),
            Contact = new OpenApiContact()
            {
                Name = "Dev Kimchi",
                Email = "no-reply@devkimchi.com",
                Url = new Uri("https://github.com/devkimchi/Azure-Functions-Face-Recognition-Sample/issues"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("http://opensource.org/licenses/MIT"),
            }
        };
    }
}
