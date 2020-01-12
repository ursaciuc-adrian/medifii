FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Src/Microservices/Search-Service/Medifii.SearchService.Api/Medifii.SearchService.Api.csproj", "Src/Microservices/Search-Service/Medifii.SearchService.Api/"]
COPY ["Src/Microservices/Search-Service/Medifii.SearchService/Medifii.SearchService.csproj", "Src/Microservices/Search-Service/Medifii.SearchService/"]
COPY ["Src/Microservices/Scraper-Service/Medifii.ScraperService/Medifii.ScraperService.csproj", "Src/Microservices/Scraper-Service/Medifii.ScraperService/"]
RUN dotnet restore "Src/Microservices/Search-Service/Medifii.SearchService.Api/Medifii.SearchService.Api.csproj"
COPY . .
WORKDIR "/src/Src/Microservices/Search-Service/Medifii.SearchService.Api"
RUN dotnet build "Medifii.SearchService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.SearchService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.SearchService.Api.dll"]