# To-do API

A REST API built with ASP.NET CORE which exposes routes to manipulate users and their tasks.

## How to run the project locally using dotnet CLI

  ### Docker

    ```

      dotnet restore
      dotnet build
      dotnet publish -c Release
      docker-compose up -d --build

    ```

  ### Without Docker

    ```

      dotnet run --project ./Api/Api.csproj

    ```

  **After following the steps above, API should be listening at ports 5009 or 5000(check [API reference](#api-reference) section)**

## API reference

  ### Auth/User Endpoints

    **Register an user**
      http://localhost:5000/api/v1/auth/register (local)
      http://localhost:5009/api/v1/auth/register (Docker)

    **Login**
      http://localhost:5000/api/v1/auth/login (local)
      http://localhost:5009/api/v1/auth/login (Docker)

  ### To-do Endpoints(Copy the Bearer JWT Token retrieved from login and paste in request headers)

    **Get All To-do Items**
      http://localhost:5000/api/v1/todo/getall-by-userid (local)
      http://localhost:5009/api/v1/todo/getall-by-userid (Docker)

## Knowledge applied

  * SOLID
  * CLEAN/ONION ARCHITECTURE
  * CQRS
  * DATABASE DESIGN AND MODELING
  * REST
  * DESIGN PATTERNS
  * UNIT AND INTEGRATION TESTS
  * CONTAINERIZATION
  * AUTHENTICATION AND AUTHORIZATION

## Technologies

  * .NET 6 RUNTIME
  * ASP.NET CORE
  * POSTGRESQL
  * DOCKER
  * MEDIATR
  * MAPSTER
  * ENTITYFRAMEWORK CORE
  * FLUENTVALIDATION
  * XUNIT
  * JWT
  * BCRYPT

## Next Steps

  * DEPLOY
  * ADD CI/CD
  * TURN RESTFUL?
  * ADD DOMAIN DRIVEN DESIGN


