using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    public static class BlobTrigger5
    {
        [FunctionName(nameof(BlobTrigger5))]
        public static void Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger5/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] BlobTriggerOptions myBlob,
            string name,
            ILogger logger)
        {
            var blobTriggerOptions = myBlob;

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger5)}.");
        }
    }
}
