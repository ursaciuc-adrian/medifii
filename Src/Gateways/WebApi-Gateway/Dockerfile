FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Src/Gateways/WebApi-Gateway/Medifii.ApiGateway.csproj", "Src/Gateways/WebApi-Gateway/"]
RUN dotnet restore "Src/Gateways/WebApi-Gateway/Medifii.ApiGateway.csproj"
COPY . .
WORKDIR "/src/Src/Gateways/WebApi-Gateway"
RUN dotnet build "Medifii.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.ApiGateway.dll"]