FROM mcr.microsoft.com/dotnet/sdk:9.0

EXPOSE 32000

WORKDIR /app

COPY ["BoardGames.SecretHitler.Orchestrator", "Orchestrator"]

WORKDIR /app/Orchestrator

RUN dotnet restore 
RUN dotnet publish -c Relise -o /app/publish

WORKDIR /app/publish

ENTRYPOINT ["dotnet", "BoardGames.SecretHitler.Orchestrator.dll"]