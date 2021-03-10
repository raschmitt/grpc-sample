
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

COPY ./ ./
RUN dotnet restore ./Service/

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Service.dll"]

RUN apt-get update && apt-get install -y curl
HEALTHCHECK CMD curl --fail http://localhost:80/health || exit

EXPOSE 80