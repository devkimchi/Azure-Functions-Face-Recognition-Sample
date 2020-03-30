using System;
using System.IO;

using System.Text;

using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FaceApiSample.FunctionApp
{
    public class RenderPageHttpTrigger
    {
        private readonly ILogger<RenderPageHttpTrigger> _logger;

        public RenderPageHttpTrigger(ILogger<RenderPageHttpTrigger> logger)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [FunctionName("RenderPageHttpTrigger")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "pages/capture")] HttpRequest req,
            ExecutionContext context)
        {
            this._logger.LogInformation("C# HTTP trigger function processed a request.");

            var filepath = $"{context.FunctionAppDirectory}/photo-capture.html";
            var file = await File.ReadAllTextAsync(filepath, Encoding.UTF8).ConfigureAwait(false);
            var result = new ContentResult()
            {
                Content = file,
                StatusCode = 200,
                ContentType = "text/html"
            };

            return result;
        }
    }
}
