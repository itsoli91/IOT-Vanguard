#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Transport/Transport.MQTT/Transport.MQTT.csproj", "src/Services/Transport/Transport.MQTT/"]
RUN dotnet restore "src/Services/Transport/Transport.MQTT/Transport.MQTT.csproj"
COPY . .
WORKDIR "/src/src/Services/Transport/Transport.MQTT"
RUN dotnet build "Transport.MQTT.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transport.MQTT.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transport.MQTT.dll"]
