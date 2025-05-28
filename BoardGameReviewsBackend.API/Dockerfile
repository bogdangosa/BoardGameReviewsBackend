FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["BoardGameReviewsBackend.API/BoardGameReviewsBackend.API.csproj", "BoardGameReviewsBackend.API/"]
COPY ["BoardGameReviewsBackend.Business/BoardGameReviewsBackend.Business.csproj", "BoardGameReviewsBackend.Business/"]
COPY ["BoardGameReviewsBackend.Data/BoardGameReviewsBackend.Data.csproj", "BoardGameReviewsBackend.Data/"]
COPY ["BoardGameReviewsBackend.Migrations/BoardGameReviewsBackend.Migrations.csproj", "BoardGameReviewsBackend.Migrations/"]
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

# Install EF CLI
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

ENV ASPNETCORE_URLS=http://0.0.0.0:10000

COPY ["BoardGameReviewsBackend.API/entrypoint.sh", "."]
RUN chmod +x entrypoint.sh
ENTRYPOINT ["./BoardGameReviewsBackend.API/entrypoint.sh"]
