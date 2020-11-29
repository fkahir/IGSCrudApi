## Fara Kahir Senior Backend Engineer 
### IGS C.R.U.D. Tech Test Submission

### Tech Stack
IGS CRUD API is build using .Net Core 3.1 and utilizes EF Core with SQL Server for Persistence. It is implemented using the Mediator design Pattern and uses the [MediatR](https://github.com/jbogard/MediatR) library.

### Install and Run
To run the application as a developer, simply pull the code and restore the nuget packages.
Prior to doing this an instance of SQL Server will be required to run locally or containerized.

If you have a locally installed instance of SQL server, please update the connection string values in appsettings.json > ConnectionStrings > DefaultConnection
*Please note the database will be created automatically*
To run a docker image of sql server, please use the following command:

`docker run --name FKSQL -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Password123+" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest`

*Please note this image works for Linux Containers*

Similarly, please update the connection string values in appsettings.json > ConnectionStrings > DefaultConnection

Please run the API from your IDE using the IGSCrud/IGSCrud IIS Express configuation. launchsettings.json has been modified to auto open the browser and set the start page to the Swagger documentation.

---

#Install and Run using Docker
You can build and run a docker image of the API, this requires the same steps above in order to have a SQL server instance either installed or running from a docker image. Once the appsettings.json has been updated with the relevant connection string details, you can build and then create a docker image:

Using your command line editor, navigate to the directory containing the DockerFile file, and run the following command:

`docker build --tag igscrud .`

Once this is complete, create your image to run:

`docker run --name igscrudfk -p 9080:80 igscrud`

This will start the API. You can navigate to [http://localhost:9080/swagger](http://localhost:9080/swagger) and you can see the API documentation.

#Install and Run using Docker-Compose

Alternativly, if you don't want/have a local/docker SQL instance, you can use docker-compose, which will build all relevant API and SQL images.

*Before you start, it's important that that connection string in appsettings.json is absolute:*
`Server=db,1433;Database=IGSDemo; User Id=sa;Password=Password123+;`

The server name `db` refers to the service created in the docker-compose file.

Using your command line editor, navigate to the directory containing the DockerFile file, and run the following command:

`docker-compose build`

Once this is complete, you can run with the following command:

`docker-compose up`

This will start the API. You can navigate to [http://localhost:9080/swagger](http://localhost:9080/swagger) and you can see the API documentation.




