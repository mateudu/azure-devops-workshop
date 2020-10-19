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
1. Enter the new Team name (`Service 01`) and click `Create`. Make sure to leave `Create an area path with the name of the team` option checked.
![Create new project team](/images/kQVX09idzc.png)
1. Repeat the previous step and create one more Team (`Service 02`).

Now, two Teams and Area Paths should be created. It's time to configure Groups.

1. Go to `https://dev.azure.com/{YOUR_ORGANIZATION_NAME}/{YOUR_PROEJCT_NAME}/_settings/permissions` and click `New Group` button.
![Create new group](/images/Nv5uosz9OQ.png)
1. Enter the Group name (`Test Approvers`), add your account to `Members` and create it.
![Create new group](/images/7exd9Q9you.png)
1. Repeat the previous step and create a group with `Prod Approvers` name.

### Create & Configure GIT Repository (policies, security, merge types)

#### New Repository

1. Go to `https://dev.azure.com/{YOUR_ORGANIZATION_NAME}/_git/{YOUR_PROEJCT_NAME}` and create a new repository, called `Service 01`.
![Description](/images/BrEfgeDnt2.png)
![Description](/images/Ipn3tzJ8vU.png)

#### Branch Policies
1. Select the `Service 01` repository and go to `Branches` tab. Open the `Branch Policies` of `master` branch.
![Description](/images/KHeeKx3BT3.png)
![Description](/images/mIxklbpUNG.png)
1. Enable policies, with following settings:
    1. **Require a minimum number of reviewers**: *Minimum number of reviewers*=1, *Allow requestors to approve their own changes*=True
    1. **Check for linked work items**: Required
    1. **Check for comment resolution**: Required
    1. **Limit merge types**: *Squash merge* ony
![Description](/images/J3477CgEGX.png)
1. Add `Service 01` as `Automatically included reviewers`. Make sure to set `Minimum number of reviewers` to **1** and leave the `Allow requestors to approve their own changes` checkbox checked.
![Description](/images/Y2ne7f5Gsb.png)

#### Pull Request bypass permission
1. Select the `Service 01` repository and go to `Branches` tab. Open the `Branch Security` of `master` branch.
![Description](/images/1IRZHCGFvQ.png)
1. Select `Project Administrators` and `Allow` option in `Bypass policies when completing pull requests` setting.
![Description](/images/qYfJ8kV9XJ.png)

### Setup Build Pipelines (YAML-based):

1. Go to `Artifacts` tab in Azure DevOps and create a new feed.
1. Go to my GitHub repository (the one that you read ;)) and clone the repository.
1. Clone the `Service 01` repository from Azure DevOps.
1. Copy the following directories from my GitHub repository, and add them to `Service 01` repository, by making a new branch locally, copying these directories and pushing that branch to `Service 01` repository:
    1. `ci`
    1. `iac`
    1. `src`
1. Make a new pull request to `master` branch, and bypass policies to complete it.
1. Go to `Pipelines` tab and add new build. As a definition source, select `ci/ci.yml` file.
1. Edit the build pipeline, to select correct Azure DevOps Feed ID.
1. Run the build.
![Description](/images/chrome_OvxFMuUfeR.png)
1. Go to `master` branch policies, as in previous steps and enable Build validation for pull requests.

#### .NET Core App Build with Unit Tests validation

There is a `MyWebApp.Web` project, that contains ASP.NET Core 3.1 web application. This project is tested by `MyWebApp.Tests` project.

#### Entity Framework database migrations with validation using Docker-based MS SQL

There is a `MyWebApp.Dabatase` project, that contains Entity Framework Core-based SQL migrations. These migrations are verified by `Verify Database migrations` job in the build pipeline.

#### NuGet packages hosted as Azure Artifacts

There is a `MyWebApp.Common` project, that is a .NET Core 3.1 Class library. This library is published as a NuGet package in NuGet Feed, created in this section.

## Day 2

### Create & Configure Release Pipeline (IaC, Code deployment)

#### Service connection setup

1. Go to [App Registrations](https://portal.azure.com/#blade/Microsoft_AAD_IAM/ActiveDirectoryMenuBlade/RegisteredApps) in Azure Active Directory.
![Description](/images/zWTuEjSIjY.png)
1. Add new App. Copy Application ID.
![Description](/images/84gzYAwtqb.png)
1. Generate Application secret and copy it (save it for later).
![Description](/images/9oDzQ3jr5k.png)
1. Go to Azure Portal and create a new Resource Group. Copy the Resource Group name, Subscription ID, Subscription Name and Tenant ID.
1. Create a new Key Vault, and assign Secret->Get/List policy to created Application. Add new secret called `my-secret` with a random text vaule.
1. Assign `Contributor` role to created SPN on created Resource Group level.
1. Go to Azure DevOps Service Connections tab. Link: `https://dev.azure.com/{YOUR_ORGANIZATION_NAME}/{YOUR_PROEJCT_NAME}/_settings/adminservices`.
1. Set up a new Service Connection.
    1. Select `Azure Resource Manager`
    ![Description](/images/0PhChfiXJU.png)
    1. Select `Service principal (manual)`
    ![Description](/images/0PhChfiXJU.png)
    1. Enter following details:
        1. **Environment**: `Azure Cloud`
        1. **Scope Level**: `Subscription`
        1. **Subscription Id**: Paste Subscription ID from previous step
        1. **Subscription Name**: Paste Subscription name
        1. **Service Principal Id**: Paste Application ID
        1. **Service principal key**: Paste Application secret
        1. **Tenant ID**: Paste Tenant ID
        1. **Service connection name**: enter `Automation SPN`
        1. **Grant access permission to all pipelines**: selected
        ![Description](/images/chrome_jIDflTmJ6q.png)

### Variable Groups configuration (standard/Key Vault-based)

#### Standard Variable Group

1. Go to Variable Groups tab. Link: `https://dev.azure.com/{YOUR_ORGANIZATION_NAME}/{YOUR_PROEJCT_NAME}/_library?itemType=VariableGroups`
1. Add new Variable Group, called `MyApp - DEV`. Add there following variables:
    1. `webApp.Name`: web application name, must be unique in Azure!
    1. `hostingPlan.Name`: the name of the App Service Plan
    1. `resourceGroup.Name`: the name of created resource group
    1. `resourceGroup.Location`: enter location name, e.g. `westeurope`
    1. `serviceConection`: enter `Automation SPN`
1. Save changes.

#### Key Vault-based Variable Group

1. Go to Variable Groups tab. Link: `https://dev.azure.com/{YOUR_ORGANIZATION_NAME}/{YOUR_PROEJCT_NAME}/_library?itemType=VariableGroups`
1. Add new Variable Group, called `MyApp - KV - DEV`. Enable `Link secrets from an Azure key vault as variables` option. Select a Key Vault, that was created in previous part of the workshop.
1. Add `my-secret` variable.
1. Save changes.

### Release Pipeline configuration

#### New Release pipeline

1. Go to Releases. Link: 
![Description](/images/KzyJpeu2Bs.png)
1. Create new release pipeline. Start witn an `Empty job`. Rename it to `MyApp`.
1. Rename the stage name to `DEV`.
1. Add artifact, from `Build` -> `Service 01`. Change selection from `Latest` default version to `Latest from a specific branch with tags` with `master` branch selected..
1. Save changes.
1. Go to 'DEV' stage.
1. Link Variable Groups to 'DEV' stage.
1. Add `ARM template deployment` step with following settings:
    1. Task version: `2.*`
    1. Subscription: `$(serviceConection)`
    1. Resource Group: `$(resourceGroup.Name)`
    1. Location: `$(resourceGroup.Location)`
    1. Template: `$(System.DefaultWorkingDirectory)/_Service 01/iac/iac.json`
    1. Override template parameters: `-appName $(webApp.Name) -hostingPlanName $(hostingPlan.Name) -location $(resourceGroup.Location)`
1. Add `Azure App Service Deploy` step with following settings:
    1. Azure subscription: `$(serviceConection)`
    1. App Service name: `$(webApp.Name)`
    1. Package or folder: `$(System.DefaultWorkingDirectory)/_Service 01/app`
    1. Application and Configuration Settings -> App settings: `-sample.setting "$(my-secret)"`

#### Linking Variable Group to Release pipeline

### Tracking deployment status in Work Items

### MS Teams notifications

### Create & Configure dashboards (with Work Item queries)
