FROM mcr.microsoft.com/dotnet/aspnet:7.0-bullseye-slim AS base
WORKDIR /app
EXPOSE 5141

ENV ASPNETCORE_URLS=http://+:5141
ENV DOTNET_NOLOGO=true
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true
ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE=true
ENV DOTNET_EnableDiagnostics=0

FROM mcr.microsoft.com/dotnet/sdk:7.0-bullseye-slim AS build
ARG configuration=Release
WORKDIR /src
COPY . .
# COPY ["Directory.Build.props", "src/"]
# COPY ["./Units.sln", "./"]
# COPY ["./src/Units.Core/Units.Core.csproj", "src/Units.Core/"]
# COPY ["./src/Units.Api/Units.Api.csproj", "src/Units.Api/"]
# COPY ["./src/Units.Application/Units.Application.csproj", "src/Units.Application/"]
# COPY ["./src/Units.Infrastructure/Units.Infrastructure.csproj", "src/Units.Infrastructure/"]

RUN dotnet restore "./Units.sln" 
COPY . .
RUN dotnet build "./Units.sln" --configuration $configuration --output /app/build --no-restore

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "./src/Units.Api/Units.Api.csproj" --configuration $configuration --output /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Units.Api.dll"]