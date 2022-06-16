FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/ApiGateway/BSC.BFF/BSC.BFF.csproj", "BSC.BFF/"]
RUN dotnet restore "src/ApiGateway/BSC.BFF/BSC.BFF.csproj"
COPY . .
WORKDIR "/src/BSC.BFF"
RUN dotnet build "BSC.BFF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BSC.BFF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BSC.BFF.dll"]
