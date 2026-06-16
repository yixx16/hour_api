# ===== Etapa de build =====
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src


COPY horas.csproj ./
RUN dotnet restore horas.csproj

# ===== Etapa de publish =====
COPY . .
RUN dotnet publish horas.csproj -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./


EXPOSE 4050

ENTRYPOINT ["dotnet", "horas.dll"]
