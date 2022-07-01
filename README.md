# Innovate and modernize apps with Data and AI

## This workshop is archived and no longer being maintained.  Content is read-only.

Wide World Importers (WWI) is a global manufacturing company that handles distribution worldwide. They manufacture more than 9,000 different SKUs for two types of businesses, B2B and B2C. WWI has 5 factories each with about 10,000 sensors each, meaning 50,000 sensors sending data in real time.

Their sensor data is collected into a Kafka cluster, collected via a custom consumer application that aggregates the events and writes the results to PostgreSQL. They have an event data store that currently runs in PostgreSQL. The status of the factory floor is reported using a web app hosted on-premises that connects to PostgreSQL.

They are running into scalability issues as they add manufacturing capacity, but while addressing this concern they would like to take the opportunity to modernize their infrastructure. In particular, they would like to modernize their solution to use microservices and apply the Event Sourcing and Command Query Responsibility Segregation (CQRS) patterns.

November 2021

## Target audience

- Application developer
- AI developer
- Data engineer
- Data scientist

## Abstract

### Workshop

In this workshop, you will look at the process of implementing a modern application with Azure services. The workshop will cover event sourcing and the Command and Query Responsibility Segregation (CQRS) pattern, data loading, data preparation, data transformation, data serving, anomaly detection, creation of a predictive maintenance model, and real-time scoring of a predictive maintenance model.

### Whiteboard design session

In this whiteboard design session, you will work with a group to design a solution for ingesting and preparing manufacturing device sensor data, as well as detecting anomalies in sensor data and creating, training, and deploying a machine learning model which can predict when device maintenance will become necessary.

At the end of this whiteboard design session, you will have learned how to capture Internet of Things (IoT) device data with Azure IoT Hub, process device data with Azure Stream Analytics, apply the Command and Query Responsibility Segregation (CQRS) pattern with Azure Functions, build a predictive maintenance model using Azure Synapse Analytics Spark notebooks, deploy the model to an Azure Machine Learning model registry, deploy the model to an Azure Container Instance, and generate predictions with Azure Functions accessing a Cosmos DB change feed.  These skills will help you modernize applications and integrate Artificial Intelligence into the application.

### Hands-on lab

In this hands-on lab, you will build a cloud processing and machine learning solution for IoT data. We will begin by deploying a factory load simulator which represents sensor data collected from a stamping press machine, which cuts, shapes, and imprints sheet metal.  The rest of the lab will show how to implement an event sourcing architecture using Azure technologies ranging from Cosmos DB to Stream Analytics to Azure Functions and more.

Using factory-generated data, you will learn how to use the Anomaly Detection service built into Stream Analytics to observe and report on abnormal machine temperature readings.  You will also learn how to apply historical machine temperature and stamping pressure values in the creation of a machine learning model to identify potential issues which might require machine adjustment.  You will deploy this predictive maintenance model and generate predictions on simulated stamp press data.

## Azure services and related products

- Azure Container Registry
- Function App
- Cosmos DB with Synapse Link
- Azure Synapse Analytics
- Azure Data Lake Storage Gen2
- Azure Machine Learning
- Azure Kubernetes Service
- Event Hubs
- Azure Stream Analytics
- Power BI

## Related references

- [MCW](https://github.com/Microsoft/MCW)

## Help & Support

We welcome feedback and comments from Microsoft SMEs & learning partners who deliver MCWs.  

***Having trouble?***

- First, verify you have followed all written lab instructions (including the Before the Hands-on lab document).
- Next, submit an issue with a detailed description of the problem.
- Do not submit pull requests. Our content authors will make all changes and submit pull requests for approval.  

If you are planning to present a workshop, *review and test the materials early*! We recommend at least two weeks prior.

### Please allow 5 - 10 business days for review and resolution of issues.
