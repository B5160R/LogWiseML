FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5026

ENV ASPNETCORE_URLS=http://+:5026

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers

# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app || chown -R appuser /Database/Data
# USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/DataCollection", "Services/DataCollection"]
COPY ["src/Shared", "Shared"]
RUN dotnet restore "Services/DataCollection/API/API.csproj"
COPY . .
WORKDIR "/src/Services/DataCollection/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]

WORKDIR /app
COPY ["src/Services/DataCollection/Database/Data", "/Database/Data"]