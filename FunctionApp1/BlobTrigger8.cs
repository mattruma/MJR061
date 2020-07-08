using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class BlobTrigger8
    {
        [FunctionName(nameof(BlobTrigger8))]
        public async static Task Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger8/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] CloudPageBlob myBlob,
            string name,
            ILogger logger)
        {
            var ms = new MemoryStream();

            await myBlob.DownloadToStreamAsync(ms);

            var body = Encoding.ASCII.GetString(ms.ToArray());

            logger.LogInformation($"{nameof(BlobTrigger8)} triggered with a body of {body}.");

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger8)}.");
        }
    }
}
