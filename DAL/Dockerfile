FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY ["BoardGames.SecretHitler.Persistence/*.csproj", "Persistence/"]

RUN dotnet restore Persistence/

COPY ["BoardGames.SecretHitler.Persistence", "Persistence/"]

WORKDIR /app/Persistence

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 32100

ENTRYPOINT ["dotnet", "BoardGames.SecretHitler.Persistence.dll"]