FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BoardGameReviewsBackend.API/BoardGameReviewsBackend.API.csproj", "BoardGameReviewsBackend.API/"]
COPY ["BoardGameReviewsBackend.Business/BoardGameReviewsBackend.Business.csproj", "BoardGameReviewsBackend.Business/"]
COPY ["BoardGameReviewsBackend.Data/BoardGameReviewsBackend.Data.csproj", "BoardGameReviewsBackend.Data/"]
RUN dotnet restore "BoardGameReviewsBackend.API/BoardGameReviewsBackend.API.csproj"
COPY . .
WORKDIR "/src/BoardGameReviewsBackend.API"
RUN dotnet build "BoardGameReviewsBackend.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BoardGameReviewsBackend.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "BoardGameReviewsBackend.API.dll"]
