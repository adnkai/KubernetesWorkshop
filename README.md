# Kubernetes Workshop
Azure AKS Workshop

### From Root Dir
docker build –t /frontend/frontend:v1 `.`  
docker build –t /backend/backend:v1 `.`

### Login to Azure Container Registry (requires Azure CLI)
az acr login –-name `[RegistryName]`

### Tag local docker images with ACR name
docker tag frontend:v1 `[RegistryName]`.azurecr.io/frontend:v1  
docker tag backend:v1 `[RegistryName]`.azurecr.io/backend:v1

### Push images to Azure Container Registry
docker push `[RegistryName]`.azurecr.io/frontend:v1  
docker push `[RegistryName]`.azurecr.io/backend:v1

### Create Azure Kubernetes Service and attach Azure Container Registry
az aks create --resource-group `[ResourceGroupName]` --name `[AKSName]` --generate-ssh-keys --attach-acr `[ACRName]`  
az aks get-credentials --resource-group `[ResourceGroupName]` --name `[AKSName]`


### If you forgot to attach ACR to AKS
az aks update --name `[AKSName]` -resource-group `[ResourceGroupName]` --attach-acr `[ACRName]`
