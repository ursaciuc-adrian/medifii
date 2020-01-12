FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Src/Microservices/Request-Service/Medifii.RequestService.Api/Medifii.RequestService.Api.csproj", "Src/Microservices/Request-Service/Medifii.RequestService.Api/"]
COPY ["Src/Microservices/Request-Service/Medifii.RequestService.DomainService/Medifii.RequestService.Repositories/Medifii.RequestService.Repositories.csproj", "Src/Microservices/Request-Service/Medifii.RequestService.DomainService/Medifii.RequestService.Repositories/"]
COPY ["Src/Microservices/Request-Service/Medifii.RequestService.DomainModel/Medifii.RequestService.Data/Medifii.RequestService.Data.csproj", "Src/Microservices/Request-Service/Medifii.RequestService.DomainModel/Medifii.RequestService.Data/"]
COPY ["Src/Microservices/Request-Service/Medifii.RequestService.DomainModel/Medifii.RequestService.Persistence/Medifii.RequestService.Persistence.csproj", "Src/Microservices/Request-Service/Medifii.RequestService.DomainModel/Medifii.RequestService.Persistence/"]
COPY ["Src/Microservices/Request-Service/Medifii.RequestService.Business/Medifii.RequestService.Serices/Medifii.RequestService.Services.csproj", "Src/Microservices/Request-Service/Medifii.RequestService.Business/Medifii.RequestService.Serices/"]
RUN dotnet restore "Src/Microservices/Request-Service/Medifii.RequestService.Api/Medifii.RequestService.Api.csproj"
COPY . .
WORKDIR "/src/Src/Microservices/Request-Service/Medifii.RequestService.Api"
RUN dotnet build "Medifii.RequestService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.RequestService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.RequestService.Api.dll"]