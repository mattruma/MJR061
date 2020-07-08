using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class QueueTrigger1
    {
        // https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-queue-trigger?tabs=csharp#message-metadata

        [FunctionName(nameof(QueueTrigger1))]
        public async static Task Run(
            [QueueTrigger("%AZURE_STORAGE_PREFIX%queuetrigger1", Connection = "AZURE_STORAGE_CONNECTION_STRING")] string myQueueItem,
            [Blob("%AZURE_STORAGE_PREFIX%queuetrigger1/{queueTrigger}", FileAccess.Read)] Stream myBlob,
            ILogger logger)
        {
            logger.LogInformation($"{nameof(QueueTrigger1)} triggered with a message of {myQueueItem}.");

            var sr = new StreamReader(myBlob);

            var body = await sr.ReadToEndAsync();

            logger.LogInformation($"{nameof(QueueTrigger1)} triggered with a body of {body}.");

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(QueueTrigger1)}.");
        }
    }
}
