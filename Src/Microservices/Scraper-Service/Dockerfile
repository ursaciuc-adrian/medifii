FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
WORKDIR /src
COPY ["Medifii.ScraperService/*.csproj", "Src/Microservices/Scraper-Service/Medifii.ScraperService/"]
COPY ["Medifii.ScraperService.Infrastructure/*.csproj", "Src/Microservices/Scraper-Service/Medifii.ScraperService.Infrastructure/"]
RUN dotnet restore "Src/Microservices/Scraper-Service/Medifii.ScraperService/Medifii.ScraperService.csproj"

COPY . .
WORKDIR "/src/Src/Microservices/Scraper-Service/Medifii.ScraperService"
RUN dotnet build "Medifii.ScraperService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.ScraperService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.ScraperService.dll"]