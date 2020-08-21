FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["project_with_enable_docker_support/project_with_enable_docker_support.csproj", "project_with_enable_docker_support/"]
RUN dotnet restore "project_with_enable_docker_support/project_with_enable_docker_support.csproj"
COPY . .
WORKDIR "/src/project_with_enable_docker_support"
RUN dotnet build "project_with_enable_docker_support.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "project_with_enable_docker_support.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "project_with_enable_docker_support.dll"]