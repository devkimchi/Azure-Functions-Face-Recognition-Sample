using System;

using FaceApiSample.FunctionApp.Configs;
using FaceApiSample.FunctionApp.Services;

using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.WindowsAzure.Storage;

using Microsoft.WindowsAzure.Storage.Blob;

[assembly: FunctionsStartup(typeof(FaceApiSample.FunctionApp.StartUp))]
namespace FaceApiSample.FunctionApp
{
    public class StartUp : FunctionsStartup
    {
        private const string StorageConnectionStringKey = "AzureWebJobsStorage";

        public override void Configure(IFunctionsHostBuilder builder)
        {
            this.ConfigureAppSettings(builder.Services);
            this.ConfigureHttpClient(builder.Services);
            this.ConfigureBlobStorage(builder.Services);
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

        private void ConfigureBlobStorage(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable(StorageConnectionStringKey);
            var blob = CloudStorageAccount.Parse(connectionString)
                                          .CreateCloudBlobClient();

            services.AddSingleton<CloudBlobClient>(blob);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IBlobService, BlobService>();
        }
    }
}
