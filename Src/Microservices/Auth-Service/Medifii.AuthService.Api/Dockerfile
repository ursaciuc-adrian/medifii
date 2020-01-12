FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Src/Microservices/Auth-Service/Medifii.AuthService.Api/Medifii.AuthService.Api.csproj", "Src/Microservices/Auth-Service/Medifii.AuthService.Api/"]
COPY ["Src/Microservices/Auth-Service/Medifii.AuthService/Medifii.AuthService.csproj", "Src/Microservices/Auth-Service/Medifii.AuthService/"]
COPY ["Src/Microservices/Common/Medifii.Common/Medifii.Common.csproj", "Src/Microservices/Common/Medifii.Common/"]
RUN dotnet restore "Src/Microservices/Auth-Service/Medifii.AuthService.Api/Medifii.AuthService.Api.csproj"
COPY . .
WORKDIR "/src/Src/Microservices/Auth-Service/Medifii.AuthService.Api"
RUN dotnet build "Medifii.AuthService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.AuthService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.AuthService.Api.dll"]