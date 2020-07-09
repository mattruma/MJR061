using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public static class HttpTrigger2
    {
        [FunctionName(nameof(HttpTrigger2))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] BlobTriggerOptions req,
            [Blob("%AZURE_STORAGE_PREFIX%httptrigger2", FileAccess.Write)] CloudBlobContainer myBlob,
            ILogger logger)
        {
            var blobTriggerOptions = req;

            var body = JsonConvert.SerializeObject(blobTriggerOptions);

            logger.LogInformation($"{nameof(HttpTrigger2)} triggered with a body of {body}.");

            var blobNameList = new List<string>();

            for (var i = 0; i < 5; i++)
            {
                var blobName = $"{Guid.NewGuid()}.json";

                blobNameList.Add(blobName);

                var cloudBlockBlob =
                    myBlob.GetBlockBlobReference(blobName);

                cloudBlockBlob.Properties.ContentType = "application/json";

                await cloudBlockBlob.UploadTextAsync(body);
            }

            return new OkObjectResult(blobNameList);
        }
    }
}
