FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY ["BoardGames.SecretHitler.Orchestrator/*.csproj", "Orchestrator/"]

RUN dotnet restore Orchestrator/

COPY ["BoardGames.SecretHitler.Orchestrator", "Orchestrator/"]

WORKDIR /app/Orchestrator

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 32000

ENTRYPOINT ["dotnet", "BoardGames.SecretHitler.Orchestrator.dll"]