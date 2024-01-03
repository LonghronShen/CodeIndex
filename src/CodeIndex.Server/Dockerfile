#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT Production
ENV CodeIndex__LuceneIndex /luceneindex
ENV CodeIndex__MonitorFolder /monitorfolder
ENV CodeIndex__IsInLinux true
ENV CodeIndex__LocalUrl http://localhost:80/
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/CodeIndex.Server/CodeIndex.Server.csproj", "src/CodeIndex.Server/"]
COPY ["src/CodeIndex.Common/CodeIndex.Common.csproj", "src/CodeIndex.Common/"]
COPY ["src/CodeIndex.MaintainIndex/CodeIndex.MaintainIndex.csproj", "src/CodeIndex.MaintainIndex/"]
COPY ["src/CodeIndex.Files/CodeIndex.Files.csproj", "src/CodeIndex.Files/"]
COPY ["src/CodeIndex.IndexBuilder/CodeIndex.IndexBuilder.csproj", "src/CodeIndex.IndexBuilder/"]
COPY ["src/CodeIndex.Search/CodeIndex.Search.csproj", "src/CodeIndex.Search/"]
COPY ["src/Directory.Build.props", "src/Directory.Build.props"]

RUN dotnet restore ./src/CodeIndex.Server/CodeIndex.Server.csproj

COPY . .

RUN dotnet build ./src/CodeIndex.Server/CodeIndex.Server.csproj -c Release -o /app/build

FROM build AS publish

WORKDIR /src/src/CodeIndex.Server/
RUN dotnet publish "CodeIndex.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CodeIndex.Server.dll"]