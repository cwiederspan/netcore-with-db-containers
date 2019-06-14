FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
#EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SqlTest.Site.csproj", ""]
RUN dotnet restore "SqlTest.Site.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "SqlTest.Site.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SqlTest.Site.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SqlTest.Site.dll"]