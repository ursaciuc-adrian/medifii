FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Src/Microservices/Reservation-Service/Medifii.ReservationService.Api/Medifii.ReservationService.Api.csproj", "Src/Microservices/Reservation-Service/Medifii.ReservationService.Api/"]
COPY ["Src/Microservices/Reservation-Service/Medifii.ReservationService/Medifii.ReservationService.csproj", "Src/Microservices/Reservation-Service/Medifii.ReservationService/"]
COPY ["Src/Microservices/Common/Medifii.Common/Medifii.Common.csproj", "Src/Microservices/Common/Medifii.Common/"]
RUN dotnet restore "Src/Microservices/Reservation-Service/Medifii.ReservationService.Api/Medifii.ReservationService.Api.csproj"
COPY . .
WORKDIR "/src/Src/Microservices/Reservation-Service/Medifii.ReservationService.Api"
RUN dotnet build "Medifii.ReservationService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Medifii.ReservationService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Medifii.ReservationService.Api.dll"]