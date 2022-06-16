FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ApiGateway/BSC.OcelotApiGw/BSC.OcelotApiGw.csproj", "BSC.OcelotApiGw/"]
RUN dotnet restore "src/ApiGateway/BSC.OcelotApiGw/BSC.OcelotApiGw.csproj"
COPY . .
WORKDIR "/src/BSC.OcelotApiGw"
RUN dotnet build "BSC.OcelotApiGw.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BSC.OcelotApiGw.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BSC.OcelotApiGw.dll"]
