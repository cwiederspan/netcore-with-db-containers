FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

COPY sshd_config /etc/ssh/
ENV SSH_PORT 2222
RUN apt-get update \
  && echo "root:Docker!" | chpasswd \
  && apt install -y --no-install-recommends openssh-server
EXPOSE $SSH_PORT

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
COPY ./init_container.sh .
#ENTRYPOINT ["dotnet", "SqlTest.Site.dll"]
ENTRYPOINT ["/bin/bash", "-c", "./init_container.sh && dotnet SqlTest.Site.dll"]
