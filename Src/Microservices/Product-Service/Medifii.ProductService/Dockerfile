FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Src/Microservices/Product-Service/Medifii.ProductService/Medifii.ProductService.csproj", "Src/Microservices/Product-Service/Medifii.ProductService/"]
COPY ["Src/Microservices/Product-Service/ProductService.DomainService/Medifii.ProductService.Repositories/Medifii.ProductService.Repositories.csproj", "Src/Microservices/Product-Service/ProductService.DomainService/Medifii.ProductService.Repositories/"]
COPY ["Src/Microservices/Product-Service/ProductService.DomainModel/Medifii.ProductService.Persistance/Medifii.ProductService.Persistence.csproj", "Src/Microservices/Product-Service/ProductService.DomainModel/Medifii.ProductService.Persistance/"]
COPY ["Src/Microservices/Product-Service/ProductService.DomainModel/Medifii.ProductService.Data/Medifii.ProductService.Data.csproj", "Src/Microservices/Product-Service/ProductService.DomainModel/Medifii.ProductService.Data/"]
COPY ["Src/Microservices/Product-Service/ProductService.Business/Medifii.ProductService.Services/Medifii.ProductService.Services.csproj", "Src/Microservices/Product-Service/ProductService.Business/Medifii.ProductService.Services/"]
RUN dotnet restore "Src/Microservices/Product-Service/Medifii.ProductService/Medifii.ProductService.csproj"
COPY . .
WORKDIR "/src/Src/Microservices/Product-Service/Medifii.ProductService"
RUN dotnet build "Medifii.ProductService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.ProductService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.ProductService.dll"]