![Microsoft Cloud Workshops](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/main/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Innovate and modernize apps with Data and AI
</div>

<div class="MCWHeader2">
Before the hands-on lab setup guide
</div>

<div class="MCWHeader3">
November 2021
</div>

Information in this document, including URL and other Internet Web site references, is subject to change without notice. Unless otherwise noted, the example companies, organizations, products, domain names, e-mail addresses, logos, people, places, and events depicted herein are fictitious, and no association with any real company, organization, product, domain name, e-mail address, logo, person, place or event is intended or should be inferred. Complying with all applicable copyright laws is the responsibility of the user. Without limiting the rights under copyright, no part of this document may be reproduced, stored in or introduced into a retrieval system, or transmitted in any form or by any means (electronic, mechanical, photocopying, recording, or otherwise), or for any purpose, without the express written permission of Microsoft Corporation.

Microsoft may have patents, patent applications, trademarks, copyrights, or other intellectual property rights covering subject matter in this document. Except as expressly provided in any written license agreement from Microsoft, the furnishing of this document does not give you any license to these patents, trademarks, copyrights, or other intellectual property.

The names of manufacturers, products, or URLs are provided for informational purposes only and Microsoft makes no representations and warranties, either expressed, implied, or statutory, regarding these manufacturers or the use of the products with any Microsoft technologies. The inclusion of a manufacturer or product does not imply endorsement of Microsoft of the manufacturer or product. Links may be provided to third party sites. Such sites are not under the control of Microsoft and Microsoft is not responsible for the contents of any linked site or any link contained in a linked site, or any changes or updates to such sites. Microsoft is not responsible for webcasting or any other form of transmission received from any linked site. Microsoft is providing these links to you only as a convenience, and the inclusion of any link does not imply endorsement of Microsoft of the site or the products contained therein.

© 2021 Microsoft Corporation. All rights reserved.

Microsoft and the trademarks listed at <https://www.microsoft.com/legal/intellectualproperty/Trademarks/Usage/General.aspx> are trademarks of the Microsoft group of companies. All other trademarks are property of their respective owners.

**Contents**

<!-- TOC -->

- [Innovate and modernize apps with Data and AI before the hands-on lab setup guide](#innovate-and-modernize-apps-with-data-and-ai-before-the-hands-on-lab-setup-guide)
  - [Requirements](#requirements)
  - [Before the hands-on lab](#before-the-hands-on-lab)
    - [Task 1: Create an Azure resource group using the Azure Portal](#task-1-create-an-azure-resource-group-using-the-azure-portal)
    - [Task 2: Deploy Azure resources](#task-2-deploy-azure-resources)
    - [Task 3: Download the hands-on lab content](#task-3-download-the-hands-on-lab-content)

<!-- /TOC -->

# Innovate and modernize apps with Data and AI before the hands-on lab setup guide

## Requirements

1. Microsoft Azure subscription must be pay-as-you-go or MSDN.

    - Trial subscriptions will not work.

2. Install [Visual Studio Code](https://code.visualstudio.com/).

    - Install the [Azure IoT Tools extension](https://marketplace.visualstudio.com/items?itemName=vsciot-vscode.azure-iot-tools).

    - Install the [C# for Visual Studio Code extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp).

    - Install the [Azure Functions extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-azurefunctions).

3. Install [the Azure Machine Learning SDK for Python](https://docs.microsoft.com/python/api/overview/azure/ml/install?view=azure-ml-py).

4. Install Docker. [Docker Desktop](https://www.docker.com/products/docker-desktop) will work for this hands-on lab and supports Windows and MacOS. For Linux, install the Docker engine through your distribution's package manager.

5. Install [Power BI Desktop](https://aka.ms/pbidesktopstore).

6. Install the latest version of [the .NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet/3.1).

## Before the hands-on lab

Duration: 15 minutes

In this exercise, you will set up your environment for use in the rest of the hands-on lab. You should follow all steps provided before attending the Hands-on lab.

### Task 1: Create an Azure resource group using the Azure Portal

In this task, you will use the Azure Portal to create a new Azure Resource Group for this lab.

1. Log into the [Azure Portal](https://portal.azure.com).

2. On the top-left corner of the portal, select the menu icon to display the menu.

    ![The portal menu icon is displayed.](media/portal-menu-icon.png "Menu icon")

3. In the left-hand menu, select **Resource Groups**.

4. At the top of the screen select the **+ New** option to add a new resource group.

   ![The Add Resource Group Menu is displayed.](media/add-resource-group-menu.png 'Resource Group Menu')

5. Create a new resource group with the name **modernize-app**, ensuring that the proper subscription and region nearest you are selected. **Please note** that currently, the only regions available for deploying to the Azure Database for PostgreSQL Hyperscale (Citus) deployment option are East US, East US 2, West US 2, North Central US, Canada Central, Australia East, Southeast Asia, North Europe, UK South, and West Europe. It is therefore recommended that you choose one of these regions for your resource group and all created resources. Once you have chosen a location, select **Review + Create**.

   ![How to Create a resource group is displayed.](media/create-resource-group.png 'Resource Group')

6. On the Summary blade, select **Create** to provision your resource group.

### Task 2: Deploy Azure resources

The below ARM template deploys several Azure resources for the labs, including Azure Synapse Analytics, Azure Database for PostgreSQL, storage accounts, Event Hubs, Stream Analytics, Key Vault, Azure Cosmos DB, Azure Machine Learning, etc.

1. Deploy the workspace through the following Azure ARM template (select the button below):

    <a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2FMicrosoft%2FMCW-Innovate-and-modernize-apps-with-Data-and-AI%2Fmain%2FHands-on%20lab%2Fsetup%2F%2Farm.json" target="_blank"><img src="https://aka.ms/deploytoazurebutton" /></a>

2. On the **Custom deployment** form fill in the fields described below.

   - **Subscription**: Select your desired subscription for the deployment.
   - **Resource group**: Select the resource group you previously created.
   - **Region**: The region where your Azure resources will be created.

   - **Unique Suffix**: This unique suffix will be used naming resources that will created as part of your deployment, such as your initials followed by the current date in YYYYMMDD format (ex. `jdh20210615`). Make sure you follow correct Azure [Resource naming](https://docs.microsoft.com/en-us/azure/cloud-adoption-framework/ready/azure-best-practices/naming-and-tagging#resource-naming) conventions.
   - **SQL Administrator Login Password**: Provide a strong password for the Azure Synapse Analytics dedicated SQL pool login that will be created as part of your deployment. [Visit here](https://docs.microsoft.com/en-us/sql/relational-databases/security/password-policy?view=sql-server-ver15#password-complexity) to read about password rules in place. Your password will be needed during the lab. Make sure you have your password noted and secured.

   ![The form is configured as described.](media/synapse-arm-template.png "Deploy Azure resources")

3. Select the **Review + create** button, then **Create**. The provisioning of your deployment resources will take approximately 6 minutes.

    > **Note**: You may experience a deployment step failing regarding Role Assignment. This error may safely be ignored.

### Task 3: Download the hands-on lab content

1. Read both steps of this task.  Once you have done that, scroll back to the top of this document and return to the top level of the repository.

    ![The link back to the top level of this workshop is selected.](media/github-top-level.png 'Microsoft Cloud Workshop')

2. Select **Code** and then select **Download ZIP** to download a compressed archive file content. This includes files in the **Hands-on lab\Resources** folder which will be necessary for the hands-on lab.

    ![The Download ZIP option is selected.](media/github-download-zip.png 'Download ZIP of Code')

You should follow all steps provided *before* performing the Hands-on lab.
