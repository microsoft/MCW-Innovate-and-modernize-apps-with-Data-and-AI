![Microsoft Cloud Workshops](https://github.com/Microsoft/MCW-Template-Cloud-Workshop/raw/main/Media/ms-cloud-workshop.png "Microsoft Cloud Workshops")

<div class="MCWHeader1">
Innovate and modernize apps with Data and AI
</div>

<div class="MCWHeader2">
Whiteboard design session student guide
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

- [Innovate and modernize apps with Data and AI whiteboard design session student guide](#innovate-and-modernize-apps-with-data-and-ai-whiteboard-design-session-student-guide)
  - [Abstract and learning objectives](#abstract-and-learning-objectives)
  - [Step 1: Review the customer case study](#step-1-review-the-customer-case-study)
    - [Customer situation](#customer-situation)
    - [Customer needs](#customer-needs)
    - [Customer objections](#customer-objections)
    - [Infographic for common scenarios](#infographic-for-common-scenarios)
  - [Step 2: Design a proof of concept solution](#step-2-design-a-proof-of-concept-solution)
  - [Step 3: Present the solution](#step-3-present-the-solution)
  - [Wrap-up](#wrap-up)
  - [Additional references](#additional-references)

<!-- /TOC -->

# Innovate and modernize apps with Data and AI whiteboard design session student guide

## Abstract and learning objectives

In this whiteboard design session, you will work with a group to design a solution for ingesting and preparing manufacturing device sensor data, as well as detecting anomalies in sensor data and creating, training, and deploying a machine learning model which can predict when device maintenance will become necessary.

At the end of this whiteboard design session, you will have learned how to capture Internet of Things (IoT) device data with Azure IoT Hub, process device data with Azure Stream Analytics, apply the Command and Query Responsibility Segregation (CQRS) pattern with Azure Functions, build a predictive maintenance model using an Azure Machine Learning notebook, deploy the model to an Azure Machine Learning model registry, deploy the model to an Azure Container Instance, and generate predictions with Azure Functions accessing a Cosmos DB change feed.  These skills will help you modernize applications and integrate Artificial Intelligence into the application.

## Step 1: Review the customer case study

**Outcome**

Analyze your customer's needs.

Timeframe: 15 minutes

Directions: With all participants in the session, the facilitator/SME presents an overview of the customer case study along with technical tips.

1. Meet your team members and trainer.

2. Read all directions for steps 1-3 in the student guide.

3. As a team, review the following customer case study.

### Customer situation

Wide World Importers (WWI) is a global manufacturing company that handles distribution worldwide. They manufacture more than 9,000 different SKUs. They have data coming from CNC machines and sensors, as well as Manufacturing Execution Systems (MES).

WWI has five factories, each with about 10,000 sensors, for a total of approximately 50,000 sensors sending data in real-time. Today, their sensor data is collected into a Kafka cluster and processed via a custom consumer application that aggregates the events and writes the results to PostgreSQL. They have an event data store that currently runs in PostgreSQL. A web app connects to the data store and reports the status of the factory floor.

WWI is running into scalability issues as they add manufacturing capacity, but in the course of addressing this concern, they would like to take the opportunity to modernize their infrastructure. In particular, they would like to modernize their solution to use microservices and apply the Event Sourcing and Command and Query Responsibility Segregation (CQRS) patterns.

They recognize their solutions will benefit from the cloud and want to ensure that they can manage their hybrid solution in a consistent way across both cloud and on-premises resources. The factories currently collect and analyze their operational data independently. They would like to deploy a cloud-based platform to centralize and allow storage of all data across all factories.

### Customer needs

1. We want to centralize our factory sensor data into the cloud, using PaaS services wherever possible.

2. We want to replace our local installations of Apache Kafka with a service that does not require on-premises administrators.  Not all our factories have dedicated Kafka administrators, which has led to avoidable data loss issues in the past.

3. The consumer group application we have built to process data from Kafka is our data pipeline bottleneck. When factory managers need to wait for information to come in, it typically is because the consumer group has fallen behind again.  We want a system that can keep up with the torrent of device data our sensors generate.

4. Our factories are spread out across the world, and factory managers are used to near-real-time responses from the web applications hosted on on-premises servers.  Instead of a pure cloud solution, we would like a hybrid cloud solution that allows our central office, located in the northwestern United States, to oversee operations while still enabling factory managers to get the information they need at the speed to which they are accustomed.

5. In addition to storing data in the cloud, we would like to integrate machine learning into our application processing, including detecting anomalies in sensor data and predicting when machine maintenance will be necessary based on sensor data.

6. We want to reduce our reliance on a classic web application server for data processing and move toward a microservice approach.

### Customer objections

1. We process a large amount of sensor data at each factory.  Will a cloud service be able to keep up with our data requirements?

2. Does Azure have any capabilities available to perform anomaly detection on our sensor data?  How quickly could we get such a service in place?

3. Will a hybrid Azure and on-premises solution require additional administrators?  We do not have the budget to hire new IT staff this fiscal year, and so we want to limit the amount of new maintenance work required.

4. How quickly could we add new sensors to this solution?  We have new manufacturing devices coming online and wish to expand the numbers of sensors on our existing devices, so we need a solution that will scale over time.

### Infographic for common scenarios

![A diagram representing a reference architecture for deploying an IoT scenario in Azure.  IoT devices push messages to a cloud gateway, which transforms data through Stream Analytics or a Function App.  The resulting data is stored in a Storage blob for machine learning, as well as Cosmos DB for use in applications and customer-facing tools such as Power BI.](media/iot.png 'The Azure IoT reference architecture')

## Step 2: Design a proof of concept solution

**Outcome**

Design a solution and prepare to present the solution to the target customer audience in a 15-minute chalk-talk format.

Timeframe: 60 minutes

**Business needs**

Directions: With your team, answer the following questions and be prepared to present your solution to others:

1. Who will you present this solution to? Who is your target customer audience? Who are the decision makers?

2. What customer business needs do you need to address with your solution?

**Design**

Directions: With your team, respond to the following questions:

*High-level architecture*

1. Without getting into the details (the following sections will address the particular details), diagram your initial vision for building a hybrid data services approach, combining on-premises infrastructure with Azure, along with custom dashboards, real-time anomaly detection, and predictive maintenance.  If you can, include the underlying architecture of the solution by identifying its major components.

*IoT options in Azure*

1. What are the SaaS-based IoT options in Azure?

2. What are the PaaS-based IoT options in Azure?

3. Would you recommend SaaS or PaaS for this customer situation? What are the pros and cons of each?

*Hybrid IoT data management*

1. How do you collect data from on-premises devices and share it between on-premises services and cloud services?

2. How do you aggregate or re-shape IoT data for consumption by downstream services?

3. Will Wide World Importers be able to support a major influx of new sensors with this solution?

*Event sourcing*

1. What does event sourcing mean in practice?  What kinds of considerations should Wide World Importers take when migrating from a classic application architecture to an event sourcing pattern?

2. How can the events flowing through the architecture be processed at scale?

3. How should WWI implement the CQRS pattern in their new microservices-based web application? Provide some samples of domain entities they can use to store the event data along with state information.

*Anomaly detection*

1. Given historical data for a sensor, how would you propose Wide World Importers detect anomalies?

2. How would this process integrate with their IoT data management solution?

*Predictive maintenance*

1. Wide World Importers has an extensive amount of sensor data going back years and wish to train a model for predictive maintenance based on this sensor data. What technologies would help them train the model given this data size?

2. Which platform would you recommend for deploying the trained model?  This deployed model should still be part of an event sourcing solution.

**Prepare**

Directions: As a team:

1. Identify any customer needs that are not addressed with the proposed solution.

2. Identify the benefits of your solution.

3. Determine how you will respond to the customer's objections.

Prepare a 15-minute chalk-talk style presentation to the customer.

## Step 3: Present the solution

**Outcome**

Present a solution to the target customer audience in a 15-minute chalk-talk format.

Timeframe: 30 minutes

**Presentation**

Directions:

1. Pair with another team.

2. One group is the Microsoft team, the other is the customer.

3. The Microsoft team presents their proposed solution to the customer.

4. The customer makes one of the objections from the list of objections.

5. The Microsoft team responds to the objection.

6. The customer team gives feedback to the Microsoft team.

7. Switch roles and repeat Steps 2-6.

## Wrap-up

Timeframe: 15 minutes

Directions: Reconvene with the larger group to hear the facilitator/SME share the preferred solution for the case study.

## Additional references

|    |            |
|----------|:-------------:|
| **Description** | **Links** |
| Azure IoT reference architecture | https://docs.microsoft.com/azure/architecture/reference-architectures/iot |
| What is Azure IoT Hub? | https://docs.microsoft.com/azure/iot-hub/about-iot-hub |
| What is Azure IoT Edge  | https://docs.microsoft.com/azure/iot-edge/about-iot-edge  |
| What is Azure Stream Analytics? | https://docs.microsoft.com/azure/stream-analytics/stream-analytics-introduction  |
| Anomaly detection in Azure Stream Analytics  | https://docs.microsoft.com/azure/stream-analytics/stream-analytics-machine-learning-anomaly-detection  |
| Cognitive Services Anomaly Detector  | https://azure.microsoft.com/services/cognitive-services/anomaly-detector/  |
| Azure Synapse Link for Cosmos DB | https://docs.microsoft.com/azure/cosmos-db/synapse-link |
| What is Azure Cosmos DB Analytical Store? | https://docs.microsoft.com/azure/cosmos-db/analytical-store-introduction |
| Azure Database for PostgreSQL | https://azure.microsoft.com/services/postgresql/ |
| An introduction to Azure Functions | https://docs.microsoft.com/azure/azure-functions/functions-overview |
| Tutorial: Run Azure Functions from Azure Stream Analytics jobs | https://docs.microsoft.com/azure/stream-analytics/stream-analytics-with-azure-functions |
| What is Azure Synapse Analytics? | https://docs.microsoft.com/azure/synapse-analytics/overview-what-is |
| Build a machine learning app with Apache Spark MLlib and Azure Synapse Analytics | https://docs.microsoft.com/azure/synapse-analytics/spark/apache-spark-machine-learning-mllib-notebook |
| Create and run machine learning pipelines with Azure Machine Learning SDK | https://docs.microsoft.com/azure/machine-learning/how-to-create-your-first-pipeline |
| Use an existing model with Azure Machine Learning | https://docs.microsoft.com/azure/machine-learning/how-to-deploy-existing-model |
| Tutorial: Deploy an image classification model in Azure Container Instances | https://docs.microsoft.com/azure/machine-learning/tutorial-deploy-models-with-aml |
| Command and Query Responsibility Segregation (CQRS) pattern | https://docs.microsoft.com/azure/architecture/patterns/cqrs |
| Implement a microservice domain model with .NET Core | https://docs.microsoft.com/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/net-core-microservice-domain-model |
