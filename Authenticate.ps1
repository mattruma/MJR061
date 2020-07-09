param (
    [string]$TenantName
)

if (Test-Path ".\Parameters.json" -PathType leaf) {
    $Parameters = (Get-Content ".\Parameters.json" | Out-String | ConvertFrom-Json) 
}

if ($TenantName.Trim() -eq "") { 
    $TenantName = $Parameters.TenantName;
}

if ($TenantName.Trim() -eq "" ) { 
    throw "'TenantName' is required, please provide a value for '-TenantName' argument or add a Parameter.json file with a value for 'TenantName' property."
}

Connect-AzAccount -Tenant $TenantName

az login --tenant $TenantName