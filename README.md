# Beymen Case Study

Basic stock api project . I used ASP.NET Core 3.1 Web API, MsSQL, Docker-Compose, Redis Cache, Swagger, Entity Framework Core.

## Getting Started

First of all, you need to clone the project to your local machine.

```
git clone https://github.com/mustafakocatepe/ECommerceCaseStudy.git
cd ECommerceCaseStudy
```

### Building

A step by step series of building that project

1. Restore the project :hammer:

```
dotnet restore
```

2. Update appsettings.json or appsettings.Development.json (Which you are working stage)

2. Change all connections for your development or production stage

3. If you want to use different Database Provider (MS SQL, MySQL etc...) You can change on Data layer File: DependencyInjection.cs (Line: 19)

```
    //For Microsoft SQL Server
    services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
```

5. Run EF Core Migrations

```
dotnet ef database update
```

## Running

### Run with Dotnet CLI

1. Run API project :bomb:

```
dotnet run -p ./ECommerce.Api/ECommerce.Api.csproj
```

### Run on Docker

Run docker compose commands in API Project :boom:

```bash
docker-compose build
docker-compose run
```

## Endpoints

Swagger link

```
http://localhost:8080/swagger/index.html
```

- `POST  /api/stocks` Stock is created for the product and variant.
- `GET   /api/products/{productCode}/stock` Returns stock by product code.
- `GET   /api/variants/{variantCode}/stock` Returns stock by variant code.

## Built With

* [.NET Core 3.1](https://www.microsoft.com/net/) 
* [MsSQL](https://www.microsoft.com/tr-tr/sql-server) 
* [Docker, Docker-Compose](https://docs.docker.com/compose/)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) - .NET ORM Tool
* [Swagger](https://swagger.io/) - API developer tools for testing and documention
* [Redis Cache](https://github.com/StackExchange/StackExchange.Redis)
* [xUnit](https://xunit.net/)

## Contributing

* If you want to contribute to codes, create pull request
* If you find any bugs or error, create an issue
