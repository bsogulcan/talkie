FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Channel.Api/Channel.Api.csproj", "Channel.Api/"]
COPY ["../Channel.Domain/Channel.Domain.csproj", "Channel.Domain/"]
COPY ["../Channel.Infrastructure/Channel.Infrastructure.csproj", "Channel.Infrastructure/"]
RUN dotnet restore "Channel.Api/Channel.Api.csproj"
COPY . .
WORKDIR "/src/Channel.Api"
RUN dotnet build "Channel.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Channel.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Channel.Api.dll"]
