using System;
using System.Threading.Tasks;

using FaceApiSample.FunctionApp.Configs;
using FaceApiSample.FunctionApp.Models;
using FaceApiSample.FunctionApp.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

using Microsoft.Extensions.Logging;

namespace FaceApiSample.FunctionApp
{
    public class PhotoCaptureHttpTrigger
    {
        private readonly AppSettings _settings;
        private readonly IBlobService _service;
        private readonly ILogger<PhotoCaptureHttpTrigger> _logger;

        public PhotoCaptureHttpTrigger(AppSettings settings, IBlobService service, ILogger<PhotoCaptureHttpTrigger> logger)
        {
            this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this._service = service ?? throw new ArgumentNullException(nameof(service));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [FunctionName("PhotoCaptureHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "api/faces/register")] HttpRequest req)
        {
            this._logger.LogInformation("C# HTTP trigger function processed a request.");

            var request = await new EmbeddedRequest(req.Body)
                                    .ProcessAsync()
                                    .ConfigureAwait(false);

            var filename = $"{this._settings.Blob.PersonGroup}/{Guid.NewGuid().ToString()}.png";

            var location = await this._service
                                     .UploadAsync(request.Body, filename, request.ContentType)
                                     .ConfigureAwait(false);

            return new CreatedResult(location, null);
        }
    }
}
