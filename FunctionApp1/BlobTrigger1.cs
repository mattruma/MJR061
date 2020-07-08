using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class BlobTrigger1
    {
        [FunctionName(nameof(BlobTrigger1))]
        public static async Task Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger1/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] Stream myBlob,
            string name,
            ILogger logger)
        {
            var sr = new StreamReader(myBlob);

            var body = await sr.ReadToEndAsync();

            logger.LogInformation($"{nameof(BlobTrigger1)} triggered with a body of {body}.");

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger1)}.");
        }
    }
}
