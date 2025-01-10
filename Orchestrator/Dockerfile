FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY ["./Orchestrator/BoardGames.SecretHitler.Orchestrator/*.csproj", "Orchestrator/Project/"]

COPY ["./Protos/", "Protos/"]

RUN dotnet restore Orchestrator/Project

COPY ["./Orchestrator/BoardGames.SecretHitler.Orchestrator", "Orchestrator/Project/"]

WORKDIR /app/Orchestrator/Project

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 32000

ENTRYPOINT ["dotnet", "BoardGames.SecretHitler.Orchestrator.dll"]