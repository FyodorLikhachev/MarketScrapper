FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FyodorLikhachev.MarketScrapper/FyodorLikhachev.MarketScrapper.csproj", "FyodorLikhachev.MarketScrapper/"]
RUN dotnet restore "FyodorLikhachev.MarketScrapper/FyodorLikhachev.MarketScrapper.csproj"
COPY . .
WORKDIR "/src/FyodorLikhachev.MarketScrapper"
RUN dotnet build "FyodorLikhachev.MarketScrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FyodorLikhachev.MarketScrapper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FyodorLikhachev.MarketScrapper.dll"]
