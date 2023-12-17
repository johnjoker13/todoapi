FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App
EXPOSE 80
EXPOSE 443

# Copy everything
COPY *.sln .
COPY Api/*.csproj ./Api/
COPY Application/*.csproj ./Application/
COPY Contracts/*.csproj ./Contracts/
COPY Domain/*.csproj ./Domain/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY UnitTests/*.csproj ./UnitTests/

# Restore as distinct layers
RUN dotnet restore

COPY Api/. ./Api/
COPY Application/. ./Application/
COPY Contracts/. ./Contracts/
COPY Domain/. ./Domain/
COPY Infrastructure/. ./Infrastructure/
COPY UnitTests/. ./UnitTests/

# Build and publish a release
WORKDIR /App/Api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/Api/out .
ENTRYPOINT ["dotnet", "Api.dll"]