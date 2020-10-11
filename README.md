# Azure DevOps Workshop

## Prerequisites
* Office 365 Access (with MS Teams Admin)
* Azure DevOps Admin access
* Azure Subscription
* Installed software: Git, Visual Studio Code, Powershell Module 'Az'

## Day 1

### Create & Configure new Azure DevOps Project

1. Go to `https://dev.azure.com/{YOUR_ORGANIZATION_NAME}/` and click `+ NEW PROJECT` button.
![Create new project in Azure DevOps](/images/6ymNTmtEKt.png)
1. Enter the project name and click `Create`.
![Create new project in Azure DevOps](/images/dtBc4o7F0j.png)
1. The new project should be created now.
![Create new project in Azure DevOps](/images/chrome_cAriUhCSHD.png)

### Create & Configure Project Team and Groups

Large projects may require more than one team. One of helpful Azure DevOps features is support for more than one project team (stream).

1. Go to `https://dev.azure.com/{YOUR_ORGANIZATION_NAME}/{YOUR_PROEJCT_NAME}/_settings/teams` and click `New Team` button.
![Create new project team](/images/mY7DYaBSvv.png)
1. Enter the new Team name and click `Create`. Make sure to leave `Create an area path with the name of the team` option checked.
![Create new project team](/images/kQVX09idzc.png)

### Create & Configure GIT Repository (policies, security, merge types)

### Setup Build Pipelines (YAML-based):

#### .NET Core App Build with Unit Tests validation

#### Entity Framework database migrations with validation using Docker-based MS SQL

#### NuGet packages hosted as Azure Artifacts

## Day 2

### Create & Configure Release Pipeline (IaC, Code deployment)

### Variable Groups configuration (standard/Key Vault-based)

### Tracking deployment status in Work Items

### MS Teams notifications

### Create & Configure dashboards (with Work Item queries)
