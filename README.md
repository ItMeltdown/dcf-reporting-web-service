# Kids Reporting Web service

Kids Reporting is an internal .Net WCF Web Service used by CSOS, wiKIDS, and Distributed Batch to create reports (PDF) using Crystal reports.

## Getting Started

### Project Structure

* CrystalReport Templates - stores reusable crystal reports layout templates for consitent report formatting.
* Kids.Reporting.Dataaccess - Handles data retriveal and persistance logic for reporting modules.
* Kids.Reporting.ServiceLibrary - shared service components or utilites used across reporitng services.
* Kids.wiKids.Data - Manages data models and access logic specfic to the WiKids module.
* Kids.WiKids.Utiltiy - Contains helper classes and utility functions for the wiKids module.
* DevRemote.Test - it holds test cases or scripts for remote development or integration testing.
* References -stores external library references or linked assemblies used in the project.
* ServiceLibrary.Test - Contains unit or integration tests for the servicelibrary project.

### Dependencies

#### Nuget

* [Dapper](https://github.com/dapperlib/dapper)
* [Elmah](https://elmah.github.io/)

#### Kids Framework

* Cache
* Core
* Data
* Net.Ftp
* Security
* Xml

### Developer Setup

Clone repository and build

## Support Documentation

None
