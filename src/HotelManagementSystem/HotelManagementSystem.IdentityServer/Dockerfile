#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HotelManagementSystem.IdentityServer/HotelManagementSystem.IdentityServer.csproj", "HotelManagementSystem.IdentityServer/"]
COPY ["Admin/HotelManagementSystem.Admin.DataAccess/HotelManagementSystem.Admin.DataAccess.csproj", "Admin/HotelManagementSystem.Admin.DataAccess/"]
COPY ["HotelManagementSystem.Contracts/HotelManagementSystem.Contracts.csproj", "HotelManagementSystem.Contracts/"]
COPY ["HotelManagementSystem.Library/HotelManagementSystem.Library.csproj", "HotelManagementSystem.Library/"]
RUN dotnet restore "./HotelManagementSystem.IdentityServer/HotelManagementSystem.IdentityServer.csproj"
COPY . .
WORKDIR "/src/HotelManagementSystem.IdentityServer"
RUN dotnet build "./HotelManagementSystem.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HotelManagementSystem.IdentityServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelManagementSystem.IdentityServer.dll"]