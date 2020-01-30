FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Weather/Weather.csproj", "Weather/"]
RUN dotnet restore "Weather/Weather.csproj"
COPY . .
WORKDIR "/src/Weather"
RUN dotnet build "Weather.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Weather.csproj" -c Release -o /app/publish
COPY Weather/Protos/weather.proto /app/publish/Protos/weather.proto

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.dll"]