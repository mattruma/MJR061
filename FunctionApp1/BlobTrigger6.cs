using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class BlobTrigger6
    {
        [FunctionName(nameof(BlobTrigger6))]
        public async static Task Run(
            [BlobTrigger("%AZURE_STORAGE_PREFIX%blobtrigger6/{name}", Connection = "AZURE_STORAGE_CONNECTION_STRING")] ICloudBlob myBlob,
            string name,
            ILogger logger)
        {
            var ms = new MemoryStream();

            await myBlob.DownloadToStreamAsync(ms);

            var body = Encoding.ASCII.GetString(ms.ToArray());

            logger.LogInformation($"{nameof(BlobTrigger6)} triggered with a body of {body}.");

            if (body.StartsWith("???")) body = body[3..]; // There is a leading character that shows up as a ? that needs to be removed, not sure what it is even there.

            var blobTriggerOptions = JsonConvert.DeserializeObject<BlobTriggerOptions>(body);

            logger.LogInformation($"Hello {blobTriggerOptions.Name} from {nameof(BlobTrigger6)}.");
        }
    }
}
