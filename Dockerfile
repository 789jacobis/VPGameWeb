FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY VpGameWeb.csproj ./
RUN dotnet restore VpGameWeb.csproj

COPY . .
RUN dotnet publish VpGameWeb.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 8080

CMD ["sh", "-c", "dotnet VpGameWeb.dll --urls http://0.0.0.0:${PORT:-8080}"]
