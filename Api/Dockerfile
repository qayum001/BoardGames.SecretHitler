FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY ["./Api/BoardGames.SecretHitler.Api/*.csproj", "Api/Project/"]

COPY ["./Protos/", "Protos/"]

RUN dotnet restore Api/Project

COPY ["./Api/BoardGames.SecretHitler.Api", "Api/Project/"]

WORKDIR /app/Api/Project/

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 32200

ENTRYPOINT ["dotnet", "BoardGames.SecretHitler.Api.dll"]