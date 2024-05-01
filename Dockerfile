FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS certs
WORKDIR /app
ARG SSL_PASSWORD
RUN dotnet dev-certs https -ep /https/aspnetapp.pfx -p $SSL_PASSWORD
RUN openssl pkcs12 -in /https/aspnetapp.pfx -out /https/aspnetapp.pem -nodes -password pass:$SSL_PASSWORD

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=certs /https/aspnetapp.pem /https/aspnetapp.pem
ENTRYPOINT ["dotnet", "website_CLB_HTSV.dll"]