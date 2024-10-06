# Etapa 1: Build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar os arquivos .csproj e restaurar as dependências
COPY ["BackEnd/SaudeSemFronteiras/SaudeSemFronteiras.WebApi/SaudeSemFronteiras.WebApi.csproj", "SaudeSemFronteiras.WebApi/"]
COPY ["BackEnd/SaudeSemFronteiras/SaudeSemFronteiras.Common/SaudeSemFronteiras.Common.csproj", "SaudeSemFronteiras.Common/"]
COPY ["BackEnd/SaudeSemFronteiras/SaudeSemFronteiras.Application/SaudeSemFronteiras.Application.csproj", "SaudeSemFronteiras.Application/"]

RUN dotnet restore "SaudeSemFronteiras.WebApi/SaudeSemFronteiras.WebApi.csproj"

# Copiar todo o código-fonte e compilar o projeto
COPY BackEnd/SaudeSemFronteiras/ ./
RUN dotnet build "SaudeSemFronteiras.WebApi/SaudeSemFronteiras.WebApi.csproj" -c Release -o /app/build

# Etapa 2: Publicação da aplicação
FROM build AS publish
RUN dotnet publish "SaudeSemFronteiras.WebApi/SaudeSemFronteiras.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 3: Execução da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish ./
ENTRYPOINT ["dotnet", "SaudeSemFronteiras.WebApi.dll"]
