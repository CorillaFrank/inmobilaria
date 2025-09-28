# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore

# 👇 PUBLICA EL PROYECTO, no la solución
RUN dotnet publish ./Portal-Inmobiliario.csproj -c Release -o /out --no-restore

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /out .

# Opcional para SQLite en contenedor (no persistente)
VOLUME ["/data"]
ENV ConnectionStrings__DefaultConnection="Data Source=/data/portal.db"

CMD ASPNETCORE_URLS=http://0.0.0.0:$PORT dotnet Portal-Inmobiliario.dll
