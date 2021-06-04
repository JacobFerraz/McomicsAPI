#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["services/MComics.API/MComics.API.csproj", "services/MComics.API/"]
COPY ["services/MComics.Business/MComics.Business.csproj", "services/MComics.Business/"]
COPY ["services/MComics.Data/MComics.Data.csproj", "services/MComics.Data/"]
COPY ["core/MComics.Core/MComics.Core.csproj", "core/MComics.Core/"]
RUN dotnet restore "services/MComics.API/MComics.API.csproj"
COPY . .
WORKDIR "/src/services/MComics.API"
RUN dotnet build "MComics.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MComics.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MComics.API.dll"]