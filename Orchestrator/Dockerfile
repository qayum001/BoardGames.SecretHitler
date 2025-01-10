FROM mcr.microsoft.com/dotnet/sdk:9.0

EXPOSE 32000

WORKDIR /app

COPY . .

WORKDIR ./BoardGames.SecretHitler.Orchestrator 

RUN dotnet restore 
RUN dotnet publish -c Relise -o /app/publish

WORKDIR ./publish

ENTRYPOINT ["dotnet", "BoardGames.SecretHitler.Orchestrator.dll"]


