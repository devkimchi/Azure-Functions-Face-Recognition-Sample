// using System;
// using System.Net;
// using System.Reflection;
// using System.Threading.Tasks;

// using Aliencube.AzureFunctions.Extensions.OpenApi.Abstractions;
// using Aliencube.AzureFunctions.Extensions.OpenApi.Attributes;
// using Aliencube.AzureFunctions.Extensions.OpenApi.Extensions;

// using FaceApiSample.FunctionApp.Configs;
// using FaceApiSample.FunctionApp.Handlers;

// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Azure.WebJobs;
// using Microsoft.Azure.WebJobs.Extensions.Http;
// using Microsoft.Extensions.Logging;

// namespace FaceApiSample.FunctionApp
// {
//     /// <summary>
//     /// This represents the HTTP trigger for Open API.
//     /// </summary>
//     public class OpenApiHttpTrigger
//     {
//         private readonly AppSettings _settings;
//         private readonly IDocument _document;
//         private readonly ISwaggerUI _ui;
//         private readonly IOpenApiDocumentHandler _handler;
//         private readonly ILogger<OpenApiHttpTrigger> _logger;

//         /// <summary>
//         /// Initializes a new instance of the <see cref="OpenApiHttpTrigger"/> class.
//         /// </summary>
//         /// <param name="settings"><see cref="AppSettings"/> instance.</param>
//         /// <param name="document"><see cref="IDocument"/> instance.</param>
//         /// <param name="ui"><see cref="ISwaggerUI"/> instance.</param>
//         /// <param name="handler"><see cref="IOpenApiDocumentHandler"/> instance.</param>
//         /// <param name="logger"><see cref="ILogger{OpenApiHttpTrigger}"/> instance.</param>
//         public OpenApiHttpTrigger(AppSettings settings, IDocument document, ISwaggerUI ui, IOpenApiDocumentHandler handler, ILogger<OpenApiHttpTrigger> logger)
//         {
//             this._settings = settings ?? throw new ArgumentNullException(nameof(settings));
//             this._document = document ?? throw new ArgumentNullException(nameof(document));
//             this._ui = ui ?? throw new ArgumentNullException(nameof(ui));
//             this._handler = handler ?? throw new ArgumentNullException(nameof(handler));
//             this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
//         }

//         /// <summary>
//         /// Invokes the HTTP trigger endpoint to get Open API document.
//         /// </summary>
//         /// <param name="req"><see cref="HttpRequest"/> instance.</param>
//         /// <param name="extension">File extension representing the document format. This MUST be either "json" or "yaml".</param>
//         /// <param name="log"><see cref="ILogger"/> instance.</param>
//         /// <returns>Open API document in a format of either JSON or YAML.</returns>
//         [FunctionName(nameof(OpenApiHttpTrigger.RenderSwaggerDocument))]
//         [OpenApiIgnore]
//         public async Task<IActionResult> RenderSwaggerDocument(
//             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "swagger.{extension}")] HttpRequest req,
//             string extension)
//         {
//             var swVersion = this._handler.GetVersion("v2");
//             var swFormat = this._handler.GetFormat(extension);
//             var assembly = Assembly.GetExecutingAssembly();

//             var result = await this._document
//                                    .InitialiseDocument()
//                                    .AddMetadata(this._settings.OpenApiInfo)
//                                    .AddServer(req, this._settings.HttpSettings.RoutePrefix)
//                                    .Build(assembly)
//                                    .RenderAsync(swVersion, swFormat)
//                                    .ConfigureAwait(false);

//             var content = new ContentResult()
//                               {
//                                   Content = result,
//                                   ContentType = swFormat.GetContentType(),
//                                   StatusCode = (int)HttpStatusCode.OK
//                               };

//             return content;
//         }

//         /// <summary>
//         /// Invokes the HTTP trigger endpoint to get Open API document.
//         /// </summary>
//         /// <param name="req"><see cref="HttpRequest"/> instance.</param>
//         /// <param name="version">Open API document spec version. This MUST be either "v2" or "v3".</param>
//         /// <param name="extension">File extension representing the document format. This MUST be either "json" or "yaml".</param>
//         /// <param name="log"><see cref="ILogger"/> instance.</param>
//         /// <returns>Open API document in a format of either JSON or YAML.</returns>
//         [FunctionName(nameof(OpenApiHttpTrigger.RenderOpenApiDocument))]
//         [OpenApiIgnore]
//         public async Task<IActionResult> RenderOpenApiDocument(
//             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "openapi/{version}.{extension}")] HttpRequest req,
//             string version,
//             string extension,
//             ILogger log)
//         {
//             var swVersion = this._handler.GetVersion(version);
//             var swFormat = this._handler.GetFormat(extension);
//             var assembly = Assembly.GetExecutingAssembly();

//             var result = await this._document
//                                    .InitialiseDocument()
//                                    .AddMetadata(this._settings.OpenApiInfo)
//                                    .AddServer(req, this._settings.HttpSettings.RoutePrefix)
//                                    .Build(assembly)
//                                    .RenderAsync(swVersion, swFormat)
//                                    .ConfigureAwait(false);

//             var content = new ContentResult()
//                               {
//                                   Content = result,
//                                   ContentType = swFormat.GetContentType(),
//                                   StatusCode = (int)HttpStatusCode.OK
//                               };

//             return content;
//         }

//         /// <summary>
//         /// Invokes the HTTP trigger endpoint to render Swagger UI in HTML.
//         /// </summary>
//         /// <param name="req"><see cref="HttpRequest"/> instance.</param>
//         /// <param name="log"><see cref="ILogger"/> instance.</param>
//         /// <returns>Swagger UI in HTML.</returns>
//         [FunctionName(nameof(OpenApiHttpTrigger.RenderSwaggerUI))]
//         [OpenApiIgnore]
//         public async Task<IActionResult> RenderSwaggerUI(
//             [HttpTrigger(AuthorizationLevel.Function, "get", Route = "swagger/ui")] HttpRequest req,
//             ILogger log)
//         {
//             var endpoint = "swagger.json";

//             var result = await this._ui
//                                    .AddMetadata(this._settings.OpenApiInfo)
//                                    .AddServer(req, this._settings.HttpSettings.RoutePrefix)
//                                    .BuildAsync()
//                                    .RenderAsync(endpoint, this._settings.SwaggerAuthKey)
//                                    .ConfigureAwait(false);

//             var content = new ContentResult()
//                               {
//                                   Content = result,
//                                   ContentType = "text/html",
//                                   StatusCode = (int)HttpStatusCode.OK
//                               };

//             return content;
//         }
//     }
// }
