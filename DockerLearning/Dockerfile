#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BotManager.API/BotManager.API.csproj", "BotManager.API/"]
RUN dotnet restore "BotManager.API/BotManager.API.csproj"
COPY . .
WORKDIR "/src/BotManager.API"
RUN dotnet build "BotManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BotManager.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BotManager.API.dll"]