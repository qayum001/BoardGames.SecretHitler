FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY ["./DAL/BoardGames.SecretHitler.Persistence/*.csproj", "Persistence/Project/"]

COPY ["./Protos/", "Protos/"]

RUN dotnet restore Persistence/Project

COPY ["./DAL/BoardGames.SecretHitler.Persistence/", "Persistence/Project/"]

WORKDIR /app/Persistence/Project

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 32100

ENTRYPOINT ["dotnet", "BoardGames.SecretHitler.Persistence.dll"]