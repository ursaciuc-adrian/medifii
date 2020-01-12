FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Src/Microservices/Pharmacy-Service/Medifii.PharmacyService/Medifii.PharmacyService.csproj", "Src/Microservices/Pharmacy-Service/Medifii.PharmacyService/"]
COPY ["Src/Microservices/Pharmacy-Service/PharmacyService.DomainService/Medifii.PharmacyService.Repositories/Medifii.PharmacyService.Repositories.csproj", "Src/Microservices/Pharmacy-Service/PharmacyService.DomainService/Medifii.PharmacyService.Repositories/"]
COPY ["Src/Microservices/Pharmacy-Service/PharmacyService.DomainModel/Medifii.PharmacyService.Persistence/Medifii.PharmacyService.Persistence.csproj", "Src/Microservices/Pharmacy-Service/PharmacyService.DomainModel/Medifii.PharmacyService.Persistence/"]
COPY ["Src/Microservices/Pharmacy-Service/PharmacyService.DomainModel/Medifii.PharmacyService.Data/Medifii.PharmacyService.Data.csproj", "Src/Microservices/Pharmacy-Service/PharmacyService.DomainModel/Medifii.PharmacyService.Data/"]
COPY ["Src/Microservices/Pharmacy-Service/PharmacyService.Business/Medifii.PharmacyService.Services/Medifii.PharmacyService.Services.csproj", "Src/Microservices/Pharmacy-Service/PharmacyService.Business/Medifii.PharmacyService.Services/"]
RUN dotnet restore "Src/Microservices/Pharmacy-Service/Medifii.PharmacyService/Medifii.PharmacyService.csproj"
COPY . .
WORKDIR "/src/Src/Microservices/Pharmacy-Service/Medifii.PharmacyService"
RUN dotnet build "Medifii.PharmacyService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.PharmacyService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.PharmacyService.dll"]