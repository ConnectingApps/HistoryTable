FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY HistoryTable/HistoryTable.csproj HistoryTable/
RUN dotnet restore HistoryTable/HistoryTable.csproj
COPY . .
WORKDIR /src/HistoryTable
RUN dotnet build HistoryTable.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish HistoryTable.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HistoryTable.dll"]
