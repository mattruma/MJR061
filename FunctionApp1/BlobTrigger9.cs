using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class BlobTrigger9
    {
        [FunctionName(nameof(BlobTrigger9))]
        public async static Task Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger9/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] CloudAppendBlob myBlob,
            string name,
            ILogger logger)
        {
            var ms = new MemoryStream();

            await myBlob.DownloadToStreamAsync(ms);

            var body = Encoding.ASCII.GetString(ms.ToArray());

            logger.LogInformation($"{nameof(BlobTrigger9)} triggered with a body of {body}.");

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger9)}.");
        }
    }
}
