# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Copiar los archivos del proyecto
COPY ./EL_BUTACAZO_BACK/*.csproj .
RUN dotnet restore

# Copiar todo el código fuente y compilar la aplicación
COPY ./EL_BUTACAZO_BACK/ .
RUN dotnet build EL_BUTACAZO_BACK.csproj -c Release -o /app

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar la aplicación publicada desde la etapa de build
COPY --from=build /app .

# Exponer el puerto para la API
EXPOSE 80

# Definir el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "EL_BUTACAZO_BACK.dll"]
