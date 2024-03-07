Employee Management API
=======================

The Employee Management API is a RESTful web service that allows for managing employee records. It is built using .NET 6 with a clean architecture and utilizes a PostgreSQL database for data persistence. The application and its database are containerized for easy setup and execution, and database migrations are managed with Liquibase.

Prerequisites
-------------

*   Docker
*   Docker Compose
*   Liquibase installed locally or available in a container

Getting Started
---------------

To get the Employee Management API up and running, follow these steps:

### 1\. Clone the repository

Clone this repository to your local machine to get started with the Employee Management API:

`git clone <repository-url>`

### 2\. Start the Application and Database

Navigate to the root directory of the project, where the `docker-compose.yml` file is located. Use Docker Compose to start all required services:

`cd EmployeeManagementApi docker-compose up -d`

This command will start both the API and the PostgreSQL database services in detached mode.

### 3\. Run Liquibase Migrations

After ensuring that the PostgreSQL service is up and running, apply the database migrations using Liquibase:

If Liquibase is installed locally on your machine:

`cd Host/migrations liquibase update --changelog-file=dbchangelog.sql`

If you prefer to run Liquibase from a Docker container, ensure your `liquibase.properties` is configured to connect to the PostgreSQL service correctly, and then run:

`docker run --network host --rm -v $(pwd):/liquibase/changelog liquibase/liquibase --defaultsFile=/liquibase/changelog/liquibase.properties update`

### 4\. Interact with the API

Once the application is running and the database is set up, you can interact with the API. It will be accessible at `http://localhost:5000` by default, providing endpoints to manage employee records.

### 5\. Stopping the Application

When you're done, you can stop and remove the Docker containers using:

`docker-compose down`

Architecture Overview
---------------------

The application is structured into the following layers following clean architecture principles:

*   **Clients**: (Placeholder for future HTTP client implementations)
*   **Contracts**: Interfaces and DTOs defining the core contracts of the application.
*   **Core**: Domain entities and business logic.
*   **Host**: The entry point for the application, hosting the Web API.
*   **Infrastructure**: Data access layer implementation using Dapper.
*   **Services**: Business logic service layer implementing contracts.

Migrations
----------

Database schema is managed using Liquibase, with migration scripts located in the `Host/migrations` directory. Make sure the database service is accessible before running migrations.

Dockerization
-------------

The application and its dependencies are fully dockerized, described by the `docker-compose.yml` file, simplifying the setup and execution process.
