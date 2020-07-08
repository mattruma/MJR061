using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;

namespace FunctionApp1
{
    public static class BlobTrigger4
    {
        [FunctionName(nameof(BlobTrigger4))]
        public static void Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger4/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] byte[] myBlob,
            string name,
            ILogger logger)
        {
            var body = Encoding.UTF8.GetString(myBlob);

            logger.LogInformation($"{nameof(BlobTrigger4)} triggered with a body of {body}.");

            if (body.StartsWith("?")) body = body[1..]; // There is a leading character that shows up as a ? that needs to be removed, not sure what it is even there.

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger4)}.");
        }
    }
}
