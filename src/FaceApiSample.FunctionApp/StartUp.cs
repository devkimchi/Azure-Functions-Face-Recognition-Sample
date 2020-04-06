using System;

using FaceApiSample.FunctionApp.Configs;
using FaceApiSample.FunctionApp.Services;

using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

[assembly: FunctionsStartup(typeof(FaceApiSample.FunctionApp.StartUp))]
namespace FaceApiSample.FunctionApp
{
    /// <summary>
    /// This represents the entity as an IoC container.
    /// </summary>
    public class StartUp : FunctionsStartup
    {
        private const string StorageConnectionStringKey = "AzureWebJobsStorage";
        private const string FaceAuthKeyKey = "Face__AuthKey";
        private const string FaceEndpointKey = "Face__Endpoint";

        /// <inheritdoc/>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            this.ConfigureAppSettings(builder.Services);
            this.ConfigureHttpClient(builder.Services);
            this.ConfigureStorage(builder.Services);
            this.ConfigureFaceClient(builder.Services);
            this.ConfigureServices(builder.Services);
        }

        private void ConfigureAppSettings(IServiceCollection services)
        {
            var settings = new AppSettings();

            services.AddSingleton<AppSettings>(settings);
        }

        private void ConfigureHttpClient(IServiceCollection services)
        {
            services.AddHttpClient();
        }

        private void ConfigureStorage(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable(StorageConnectionStringKey);
            var storage = CloudStorageAccount.Parse(connectionString);
            var blob = storage.CreateCloudBlobClient();
            var table = storage.CreateCloudTableClient();

            services.AddSingleton<CloudBlobClient>(blob);
            services.AddSingleton<CloudTableClient>(table);
        }

        private void ConfigureFaceClient(IServiceCollection services)
        {
            var authKey = Environment.GetEnvironmentVariable(FaceAuthKeyKey);
            var endpoint = Environment.GetEnvironmentVariable(FaceEndpointKey);
            var credentials = new ApiKeyServiceClientCredentials(authKey);
            var face = new FaceClient(credentials) { Endpoint = endpoint };

            services.AddSingleton<IFaceClient>(face);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBlobService, BlobService>();
            services.AddTransient<IFaceService, FaceService>();
        }
    }
}
