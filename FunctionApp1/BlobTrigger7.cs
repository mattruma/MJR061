using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class BlobTrigger7
    {
        [FunctionName(nameof(BlobTrigger7))]
        public async static Task Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger7/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] CloudBlockBlob myBlob,
            string name,
            ILogger logger)
        {
            var body = await myBlob.DownloadTextAsync();

            logger.LogInformation($"{nameof(BlobTrigger7)} triggered with a body of {body}.");

            if (body.StartsWith("?")) body = body[1..]; // There is a leading character that shows up as a ? that needs to be removed, not sure what it is even there.

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger7)}.");
        }
    }
}
