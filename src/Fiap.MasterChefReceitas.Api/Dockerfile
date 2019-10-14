FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Fiap.MasterChefReceitas.Api/Fiap.MasterChefReceitas.Api.csproj", "src/Fiap.MasterChefReceitas.Api/"]
RUN dotnet restore "src/Fiap.MasterChefReceitas.Api/Fiap.MasterChefReceitas.Api.csproj"
COPY . .
WORKDIR "/src/src/Fiap.MasterChefReceitas.Api"
RUN dotnet build "Fiap.MasterChefReceitas.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Fiap.MasterChefReceitas.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fiap.MasterChefReceitas.Api.dll"]