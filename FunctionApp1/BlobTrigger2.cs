using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class BlobTrigger2
    {
        [FunctionName(nameof(BlobTrigger2))]
        public static async Task Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger2/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] TextReader myBlob,
            string name,
            ILogger logger)
        {
            var body = await myBlob.ReadToEndAsync();

            logger.LogInformation($"{nameof(BlobTrigger2)} triggered with a body of {body}.");

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger2)}.");
        }
    }
}
