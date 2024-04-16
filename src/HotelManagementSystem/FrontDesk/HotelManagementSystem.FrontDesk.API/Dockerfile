#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5005
EXPOSE 5006

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FrontDesk/HotelManagementSystem.FrontDesk.API/HotelManagementSystem.FrontDesk.API.csproj", "FrontDesk/HotelManagementSystem.FrontDesk.API/"]
COPY ["FrontDesk/HotelManagementSystem.FrontDesk.Blanket/HotelManagementSystem.FrontDesk.Blanket.csproj", "FrontDesk/HotelManagementSystem.FrontDesk.Blanket/"]
COPY ["FrontDesk/HotelManagementSystem.FrontDesk.DataAccess/HotelManagementSystem.FrontDesk.DataAccess.csproj", "FrontDesk/HotelManagementSystem.FrontDesk.DataAccess/"]
COPY ["HotelManagementSystem.Library/HotelManagementSystem.Library.csproj", "HotelManagementSystem.Library/"]
COPY ["HotelManagementSystem.Contracts/HotelManagementSystem.Contracts.csproj", "HotelManagementSystem.Contracts/"]
RUN dotnet restore "./FrontDesk/HotelManagementSystem.FrontDesk.API/HotelManagementSystem.FrontDesk.API.csproj"
COPY . .
WORKDIR "/src/FrontDesk/HotelManagementSystem.FrontDesk.API"
RUN dotnet build "./HotelManagementSystem.FrontDesk.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HotelManagementSystem.FrontDesk.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelManagementSystem.FrontDesk.API.dll"]