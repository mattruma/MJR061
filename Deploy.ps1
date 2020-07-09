param (
    [string]$LocationName = "eastus",
    [string]$PrefixName
)

if (Test-Path ".\Parameters.json" -PathType leaf) {
    $Parameters = (Get-Content ".\Parameters.json" | Out-String | ConvertFrom-Json) 
}

if ($PrefixName.Trim() -eq "") { 
    $PrefixName = $Parameters.PrefixName
}

if ($PrefixName.Trim() -eq "" ) { 
    throw "'PrefixName' is required, please provide a value for '-PrefixName' argument or add a Parameter.json file with a value for 'PrefixName' property."
}

if ($LocationName.Trim() -eq "") { 
    $LocationName = $Parameters.LocationName
}

if ($LocationName.Trim() -eq "" ) { 
    throw "'LocationName' is required, please provide a value for '-LocationName' argument or add a Parameter.json file with a value for 'LocationName' property."
}

# Resource Groups

$ResourceGroupName = "$($PrefixName)-rg"

az group create -l $LocationName -n $ResourceGroupName

# Storage Accounts

$StorageAccountName = "$($PrefixName)st".Replace("-", "")

az storage account create -n $StorageAccountName -g $ResourceGroupName

# Containers

$StorageAccountKey = Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -AccountName $StorageAccountName | Where-Object { $_.KeyName -eq "key1" }

$ContainerName = "$($PrefixName)-blobtrigger1"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-blobtrigger2"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-blobtrigger3"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-blobtrigger4"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-blobtrigger5"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-blobtrigger6"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-blobtrigger7"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-blobtrigger8"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-blobtrigger9"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-httptrigger1"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-httptrigger2"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

$ContainerName = "$($PrefixName)-queuetrigger1"

az storage container create -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value
az storage container set-permission -n $ContainerName --account-name $StorageAccountName --account-key $StorageAccountKey.Value --public-access off

# Queues

$QueueName = "$($PrefixName)-queuetrigger1"

az storage queue create -n $QueueName --account-name $StorageAccountName --account-key $StorageAccountKey.Value

# Function Apps

$StorageAccountName = "$($PrefixName)001func".Replace("-", "")

az storage account create -n $StorageAccountName -g $ResourceGroupName

$FuncAppName = "$($PrefixName)-001-func"

az functionapp create -g $ResourceGroupName -n $FuncAppName -s $StorageAccountName --consumption-plan-location $LocationName --os-type Windows --runtime dotnet --functions-version 3 
