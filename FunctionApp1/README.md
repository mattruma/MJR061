# Blob Azure Functions

For more information see <https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp>.

When you're developing locally, app settings go into the local.settings.json file.

```
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "AZURE_STORAGE_PREFIX": "",
    "AZURE_STORAGE_CONNECTION_STRING": ""
  }
}
```

## Triggers

| Name | Trigger | Input | Output | Notes |
| --- | --- | --- | --- | --- |
| BlobTrigger1 | Blob - Stream |  |  |  |
| BlobTrigger2 | Blob - TextReader |  |  |  |
| BlobTrigger3 | Blob - String |  |  |  |
| BlobTrigger4 | Blob - Byte[] |  |  |  |
| BlobTrigger5 | Blob - A POCO serializable as JSON |  |  | Error - Can't bind BlobTrigger to type 'FunctionApp1.BlobTriggerOptions'. |
| BlobTrigger6 | Blob - ICloudBlob |  |  |  |
| BlobTrigger7 | Blob - CloudBlockBlob |  |  |  |
| BlobTrigger8 | Blob - CloudPageBlob |  |  | Error - The blob is not an CloudPageBlob. |
| BlobTrigger9 | Blob - CloudAppendBlob |  |  | Error - The blob is not an CloudAppendBlob. |

## Input

| Name | Trigger | Input | Output | Notes |
| --- | --- | --- | --- | --- |
| QueueTrigger1 | QueueTrigger - String | Blob - Stream |  |  |
| QueueTrigger2 | QueueTrigger - String | Blob - TextReader |  |  |

## Output

| Name | Trigger | Input | Output | Notes |
| --- | --- | --- | --- | --- |
| HttpTrigger1 | HttpTrigger - A POCO serializable as JSON |  | Blob - CloudBlobContainer |  |
| HttpTrigger2 | HttpTrigger - A POCO serializable as JSON |  | Blob - CloudBlobContainer | Outputs multiple blobs. |

