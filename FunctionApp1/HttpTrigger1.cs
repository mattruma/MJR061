using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class HttpTrigger1
    {
        [FunctionName(nameof(HttpTrigger1))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] BlobTriggerOptions req,
            [Blob("%AZURE_STORAGE_PREFIX%httptrigger1", FileAccess.Write)] CloudBlobContainer myBlob,
            ILogger logger)
        {
            var blobTriggerOptions = req;

            var body = JsonConvert.SerializeObject(blobTriggerOptions);

            logger.LogInformation($"{nameof(HttpTrigger1)} triggered with a body of {body}.");

            var blobName = $"{Guid.NewGuid()}.json";

            var cloudBlockBlob =
                myBlob.GetBlockBlobReference(blobName);

            cloudBlockBlob.Properties.ContentType = "application/json";

            await cloudBlockBlob.UploadTextAsync(body);

            return new OkObjectResult(blobName);
        }
    }
}
