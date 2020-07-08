# Blob Azure Functions

For more information see <https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp>.

## Contents

| ☑️ | Name | Trigger | Input | Output | Notes |
| --- | --- | --- | --- | --- | --- |
| ☑️ | BlobTrigger1 | Blob - Stream |  |  |  |
| ☑️ | BlobTrigger2 | Blob - TextReader |  |  |  |
| ☑️ | BlobTrigger3 | Blob - String |  |  |  |
| ☑️ | BlobTrigger4 | Blob - Byte[] |  |  |  |
| ❌ | BlobTrigger5 | Blob - A POCO serializable as JSON |  |  |  Can't bind BlobTrigger to type 'FunctionApp1.BlobTriggerOptions'. |
| ☑️ | BlobTrigger6 | Blob - ICloudBlob |  |  |  |
| ☑️ | BlobTrigger7 | Blob - CloudBlockBlob |  |  |  |
| ❌ | BlobTrigger8 | Blob - CloudPageBlob |  |  |The blob is not an CloudPageBlob. |
| ❌ | BlobTrigger9 | Blob - CloudAppendBlob |  |  | The blob is not an CloudAppendBlob. |

