FROM mcr.microsoft.com/dotnet/core/sdk:3.0-alpine AS build
WORKDIR /app

COPY . ./
RUN dotnet restore Medifii.ScraperService/*.csproj
RUN dotnet publish Medifii.ScraperService/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-alpine AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Medifii.ScraperService.dll"]