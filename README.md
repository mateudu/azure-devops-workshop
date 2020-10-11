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
1. Select the `Service 01` repository and go to `Branches` tab. Open the `Branch Policies` of `main` branch.
![Description](/images/KHeeKx3BT3.png)
![Description](/images/mIxklbpUNG.png)
1. Enable policies, with following settings:
  1. **Require a minimum number of reviewers**: *Minimum number of reviewers*=1, *Allow requestors to approve their own changes*=True
  1. **Check for linked work items**: Required
  1. **Check for comment resolution**: Required
  1. **Limit merge types**: *Squash merge* ony
1. Add `Service 01` as `Automatically included reviewers`. Make sure to set `Minimum number of reviewers` to **1** and leave the `Allow requestors to approve their own changes` checkbox checked.
![Description](/images/Y2ne7f5Gsb.png)

#### Pull Request bypass permission

### Setup Build Pipelines (YAML-based):

#### .NET Core App Build with Unit Tests validation

#### Entity Framework database migrations with validation using Docker-based MS SQL

#### NuGet packages hosted as Azure Artifacts

## Day 2

### Create & Configure Release Pipeline (IaC, Code deployment)

#### Service connection setup

#### New Release pipeline

### Variable Groups configuration (standard/Key Vault-based)

#### New Variable Group

#### Linking Variable Group to Release pipeline

### Tracking deployment status in Work Items

### MS Teams notifications

### Create & Configure dashboards (with Work Item queries)
