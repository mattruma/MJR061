# Azure Functions

Functions is a great solution for processing bulk data, integrating systems, working with the internet-of-things (IoT), and building simple APIs and micro-services.

This repository contains code samples for the following Triggers and bindings.

## Environment

Add a `Parameters.json` file.

```json
{
    "TenantName": "YOUR_TENANT_NAME.onmicrosoft.com",
    "LocationName": "LOCATION_NAME",
    "PrefixName": "YOUR_PREFIX_NAME"
}
```

In Powershell, run the `Authenticate.ps1` and then `Deploy.ps1`.

This will create all the required resources in Azure, including a single Resource Group, Storage Accounts and Azure Functions.

## Blob Storage Functions

Azure Functions integrates with Azure Storage via triggers and bindings. Integrating with Blob storage allows you to build functions that react to changes in blob data as well as read and write values.

[FunctionApp1](/FunctionApp1) contains examples on how to work with Blob Storage with Azure Functions.

### Related Articles

- Overview <https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob>
- Trigger <https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp>
- Input <https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-input?tabs=csharp>
- Output <https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-output?tabs=csharp>
