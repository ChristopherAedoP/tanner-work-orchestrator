FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Tanner.Work.Orchestrator.API/Tanner.Work.Orchestrator.API.csproj", "Tanner.Work.Orchestrator.API/"]
RUN dotnet restore "Tanner.Work.Orchestrator.API/Tanner.Work.Orchestrator.API.csproj"
COPY . .
WORKDIR "/src/Tanner.Work.Orchestrator.API"
RUN dotnet build "Tanner.Work.Orchestrator.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tanner.Work.Orchestrator.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tanner.Work.Orchestrator.API.dll"]