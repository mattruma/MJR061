using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class QueueTrigger2
    {
        [FunctionName(nameof(QueueTrigger2))]
        public async static Task Run(
            [QueueTrigger("%AZURE_STORAGE_PREFIX%queuetrigger2", Connection = "AZURE_STORAGE_CONNECTION_STRING")] string myQueueItem,
            [Blob("%AZURE_STORAGE_PREFIX%queuetrigger2/{queueTrigger}", FileAccess.Read)] TextReader myBlob,
            ILogger logger)
        {
            logger.LogInformation($"{nameof(QueueTrigger2)} triggered with a message of {myQueueItem}.");

            var body = await myBlob.ReadToEndAsync();

            logger.LogInformation($"{nameof(QueueTrigger2)} triggered with a body of {body}.");

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(QueueTrigger2)}.");
        }
    }
}
