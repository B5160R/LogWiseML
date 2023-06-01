FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ["src/GUI/Monitor", ""]
RUN dotnet restore Monitor.csproj

COPY . .
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:7.0-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "Monitor.dll"]