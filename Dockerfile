
# ===============================

# Stage 1: Build da aplicação

# ===============================

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
 
# Copiar arquivos de projeto primeiro (otimiza cache)

COPY PerifaFlowReal.api/PerifaFlowReal.api.csproj ./PerifaFlowReal.api/

COPY PerifaFlowReal.Domain/PerifaFlowReal.Domain.csproj ./PerifaFlowReal.Domain/

COPY PerifaFlowReal.Infastructure/PerifaFlowReal.Infastructure.csproj ./PerifaFlowReal.Infastructure/
 
# Restaurar dependências

RUN dotnet restore PerifaFlowReal.api/PerifaFlowReal.api.csproj
 
# Copiar todo o código

COPY . .
 
# Build e publish

WORKDIR /src/PerifaFlowReal.api

RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false
 
# ===============================

# Stage 2: Runtime

# ===============================

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
 
 
# Criar usuário não-root

RUN groupadd appgroup && useradd -M -s /bin/sh -g appgroup appuser

USER appuser
 
# Copiar arquivos publicados do stage build

COPY --from=build /app/publish .
 
# Expor porta da aplicação

EXPOSE 8080
 
# Comando de execução

ENTRYPOINT ["dotnet", "PerifaFlowReal.api.dll"]
 
