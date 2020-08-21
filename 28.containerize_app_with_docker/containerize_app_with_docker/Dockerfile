FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["containerize_app_with_docker/containerize_app_with_docker.csproj", "containerize_app_with_docker/"]
COPY ["ClassLibrary2/ClassLibrary2.csproj", "ClassLibrary2/"]
RUN dotnet restore "containerize_app_with_docker/containerize_app_with_docker.csproj"
COPY . .
WORKDIR "/src/containerize_app_with_docker"
RUN dotnet build "containerize_app_with_docker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "containerize_app_with_docker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "containerize_app_with_docker.dll"]