FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY ["BoardGames.SecretHitler.Api/*.csproj", "Api/"]

RUN dotnet restore Api/

COPY ["BoardGames.SecretHitler.Api", "Api/"]

WORKDIR /app/Api

RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 32200

ENTRYPOINT ["dotnet", "BoardGames.SecretHitler.Api.dll"]