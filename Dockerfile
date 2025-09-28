# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia y restaura
COPY . .
RUN dotnet restore

# Publica en Release a /out
RUN dotnet publish -c Release -o /out --no-restore

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia los artefactos publicados
COPY --from=build /out .

# (Opcional) directorio para SQLite dentro del contenedor
VOLUME ["/data"]
# Si usas SQLite, forzamos a guardar el .db en /data
ENV ConnectionStrings__DefaultConnection="Data Source=/data/portal.db"

# Render expone la variable PORT; arrancamos Kestrel en ese puerto
CMD ASPNETCORE_URLS=http://0.0.0.0:$PORT dotnet Portal-Inmobiliario.dll
