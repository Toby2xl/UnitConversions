# UnitConversions

A .Net 7 web Api project that shows various conversions from metrics to imperial units.

## Running and Building with Docker Compose

This guide provides step-by-step instructions to run and build a project using Docker Compose.

## Prerequisites

Before you begin, ensure you have the following installed:

- Docker: [Download and Install Docker](https://docs.docker.com/get-docker/)
- Docker Compose: [Install Docker Compose](https://docs.docker.com/compose/install/)

## Getting Started

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/Toby2xl/UnitConversions.git
   cd UnitConversions/
   ```

## Running the Application

1. Open a terminal and navigate to the project directory

    ```bash
    cd UnitsConversions/
    ``````

1. Build and start the Docker containers defined in the `docker-compose.yml` file:

    ```bash
    docker-compose up -d
    ``````

1. Access your application in a web browser by navigating to <http://localhost:8080>
1. To stop and remove the Docker containers:

     ```bash
      docker-compose down

    ``````
