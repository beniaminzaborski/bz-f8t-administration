# F8T (Feet On The Tarmac) - Administration
![Project logo](./doc/f8t-logo.png)

## Table of contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [F8T repositories](#f8t-repositories)

## General info
F8T is version of Feet On The Tarmac (FOTT) project for K8s. Originally FOTT project was built on Azure PaaS approach. 
It means was strongly related to Azure platform services such as Azure Functions for example. 
F8T based on the approach where all services are contenerizable and runnable in K8S. 
This repository contains source code of Administration service. In the repo is a GitHub Actions workflow included which is responsible for build and deploy application into Azure Kubernetes Service (AKS).
	
## Technologies
Project is created with:
* C#
* .NET 7
* Entity Framework Core
* PostgreSQL
* Open Telemetry
* MassTransit
* MediatR
* Fluent Migrator
* Fluent Validation
* AutoMapper
* Scrutor
* Azure Service Bus
* Azure Application Insights

## Setup
To deploy this project from GitHub Actions:
* In your Azure KeyVault resource assign 'get' secrets permissions for you service principal (for example "f8t-github-actions")

* Define GitHub Actions secret named AZURE_CREDENTIALS and put there the credentails of your [service principal](https://github.com/beniaminzaborski/bz-f8t-infrastructure#setup) generated before creating infrastructure

* Create new Personal Access Token in your GitHub (Settings -> Developer Settings) and store its value

* Define GitHub Actions secret named NUGET_TOKEN and put there value of GitHub Personal Access Token from previous step

* Define GitHub Actions variable named NUGET_FEED_URL and put there the URL of your GitHub Packages (https://nuget.pkg.github.com/<your account name>/index.json)

* Define GitHub Actions variable named AZURE_REGION_SHORT_NAME and put there a short name of your Azure region, for example 'westeu' for westeurope

* Create Environments in GitHub such as 'dev', 'uat', 'prod'

* Define GitHub Actions secret named REGISTRY_LOGIN_SERVER for all environments and put there value of your Azure Container Registry URL

* Define GitHub Actions secret named REGISTRY_USERNAME for all environments and put there value of username for your Azure Container Registry

* Define GitHub Actions secret named REGISTRY_PASSWORD for all environments and put there value of password for the user for your Azure Container Registry

* Run GitHub workflow named 'Build a docker image and push to the container registry' to deploy service into AKS

## F8T repositories
* Infrastructure: [github.com/beniaminzaborski/bz-f8t-infrastructure](https://github.com/beniaminzaborski/bz-f8t-infrastructure)
* Administration (this one): [github.com/beniaminzaborski/bz-f8t-administration](https://github.com/beniaminzaborski/bz-f8t-administration)
* Registration: [github.com/beniaminzaborski/bz-f8t-registration](https://github.com/beniaminzaborski/bz-f8t-registration)