using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionApp1
{
    public static class BlobTrigger3
    {
        [FunctionName(nameof(BlobTrigger3))]
        public static void Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger3/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] string myBlob,
            string name,
            ILogger logger)
        {
            var body = myBlob;

            logger.LogInformation($"{nameof(BlobTrigger3)} triggered with a body of {body}.");

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger3)}.");
        }
    }
}
