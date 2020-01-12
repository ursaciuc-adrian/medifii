FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Src/Microservices/Scraper-Service/Medifii.ScraperService.Api/Medifii.ScraperService.Api.csproj", "Src/Microservices/Scraper-Service/Medifii.ScraperService.Api/"]
COPY ["Src/Microservices/Scraper-Service/Medifii.ScraperService/Medifii.ScraperService.csproj", "Src/Microservices/Scraper-Service/Medifii.ScraperService/"]
RUN dotnet restore "Src/Microservices/Scraper-Service/Medifii.ScraperService.Api/Medifii.ScraperService.Api.csproj"
COPY . .
WORKDIR "/src/Src/Microservices/Scraper-Service/Medifii.ScraperService.Api"
RUN dotnet build "Medifii.ScraperService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.ScraperService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.ScraperService.Api.dll"]