FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy solution and all projects
COPY test_core_docker_webapi/*.csproj ./test_core_docker_webapi/
COPY Data/*.csproj ./Data/
RUN dotnet restore ./test_core_docker_webapi/test_core_docker_webapi.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish ./test_core_docker_webapi/test_core_docker_webapi.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "test_core_docker_webapi.dll"]