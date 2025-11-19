#base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
LABEL service="SFC.Team.Api" author="Kryvoruk Andrii" email="krivorukandrey@gmail.com"
USER root
WORKDIR /app

#restore & build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
ENV HUSKY=False
WORKDIR /source
COPY ["Directory.Build.props", "."]
COPY ["nuget.config", "."]
COPY ["src/API/SFC.Team.Api/SFC.Team.Api.csproj", "src/API/SFC.Team.Api/"]
COPY ["src/Core/SFC.Team.Application/SFC.Team.Application.csproj", "src/Core/SFC.Team.Application/"]
COPY ["src/Core/SFC.Team.Domain/SFC.Team.Domain.csproj", "src/Core/SFC.Team.Domain/"]
COPY ["src/Infrastructure/SFC.Team.Infrastructure/SFC.Team.Infrastructure.csproj", "src/Infrastructure/SFC.Team.Infrastructure/"]
COPY ["src/Infrastructure/SFC.Team.Infrastructure.Persistence/SFC.Team.Infrastructure.Persistence.csproj", "src/Infrastructure/SFC.Team.Infrastructure.Persistence/"]
COPY ["src/Contracts/SFC.Team.Contracts/SFC.Team.Contracts.csproj", "src/Contracts/SFC.Team.Contracts/"]
COPY ["src/Contracts/SFC.Team.Messages/SFC.Team.Messages.csproj", "src/Contracts/SFC.Team.Messages/"]
RUN dotnet restore "./src/API/SFC.Team.Api/SFC.Team.Api.csproj" --property:HUSKY=$HUSKY
COPY [".", "."]
WORKDIR "/source/src/API/SFC.Team.Api"
RUN dotnet build "./SFC.Team.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --output /app/build

#publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SFC.Team.Api.csproj" --configuration $BUILD_CONFIGURATION --property:HUSKY=$HUSKY --property:UseAppHost=false --output /app/publish

#final
FROM base AS final
ARG HTTP_PORT=8080
ARG HTTPS_PORT=8081
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE $HTTP_PORT
EXPOSE $HTTPS_PORT
ENTRYPOINT ["bash", "entrypoint.sh"]