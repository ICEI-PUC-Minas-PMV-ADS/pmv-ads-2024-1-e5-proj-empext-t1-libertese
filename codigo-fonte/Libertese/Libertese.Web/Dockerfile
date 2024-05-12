#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Libertese.Web/Libertese.Web.csproj", "Libertese.Web/"]
COPY ["Libertese.Data/Libertese.Data.csproj", "Libertese.Data/"]
COPY ["Libertese.Domain/Libertese.Domain.csproj", "Libertese.Domain/"]
RUN dotnet restore "./Libertese.Web/Libertese.Web.csproj"
COPY . .
WORKDIR "/src/Libertese.Web"
RUN dotnet build "./Libertese.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Libertese.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Libertese.Web.dll"]