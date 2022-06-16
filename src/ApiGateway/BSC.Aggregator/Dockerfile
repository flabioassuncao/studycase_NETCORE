FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ApiGateway/BSC.Aggregator/BSC.Aggregator.csproj", "BSC.Aggregator/"]
RUN dotnet restore "src/ApiGateway/BSC.Aggregator/BSC.Aggregator.csproj"
COPY . .
WORKDIR "/src/BSC.Aggregator"
RUN dotnet build "BSC.Aggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BSC.Aggregator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BSC.Aggregator.dll"]
