FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Fiap.MasterChefReceitas.Web/Fiap.MasterChefReceitas.Web.csproj", "Fiap.MasterChefReceitas.Web/"]
RUN dotnet restore "Fiap.MasterChefReceitas.Web/Fiap.MasterChefReceitas.Web.csproj"
COPY . .
WORKDIR "/src/Fiap.MasterChefReceitas.Web"
RUN dotnet build "Fiap.MasterChefReceitas.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Fiap.MasterChefReceitas.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Fiap.MasterChefReceitas.Web.dll"]