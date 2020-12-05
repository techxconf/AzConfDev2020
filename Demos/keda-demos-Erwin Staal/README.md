# keda-demos
This repository contains demo code I used while presenting on KEDA (keda.sh)

## Azure Queue
azure-queue-demo contains an Azure Function that gets triggered by items on an Azure Queue. azure-queue-filler is a small commandline app to add simple messages to the queue to test the azure-queue-demo

This [blog](https://erwinstaal.nl/posts/autoscaling-your-azure-function-on-kubernetes/) contains a complete walk-through creating this example but also setting-up an AKS cluster and deploy KEDA.

Add a local.settings.json file containing this json:
```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "<storage-connection-string>",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
    }
}
```

Then either run
```powershell
func kubernetes deploy --name hello-keda --registry <dockerID> --dry-run > deploy.yaml
kubectl apply -f deploy.yaml
```
or
```powershell
func kubernetes deploy --name hello-keda --registry <dockerID>
```

## Prometheus
The prometheus-netcore-api-demo folder contains a .NET Core API that exposes metrics to Prometheus. KEDA will scale that deployment based on the number of requests. Deploy using
```powershell
kubectl apply -f prometheus.yaml
kubectl apply -f app.yaml
kubectl apply -f keda-prometheus-scaledobject.yaml
```

## Job
console-job-demo contains an .NET Core console application that reads data from an Azure queue. Deploy that using
```powershell
kubectl apply -f job.yaml
```
and then add an item to your queue.