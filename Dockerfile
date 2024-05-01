# Bước 1: Sử dụng image aspnet 6.0
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Bước 2: Thêm các tệp certificate và private key vào container
COPY Certificates/certificate.crt /app
COPY Certificates/private.key /app
COPY Certificates/your_certificate.pfx /app

# Bước 3: Thiết lập HTTPS cho Kestrel
ENV ASPNETCORE_URLS=http://+:80;https://+:443
RUN sed -i 's/TLSv1.2/TLSv1.0 TLSv1.1 TLSv1.2/g' /etc/ssl/openssl.cnf

# Bước 4: Sử dụng biến môi trường cho mật khẩu SQL và SSL
ARG SSL_PASSWORD
ENV SSL_PASSWORD=$SSL_PASSWORD

# Bước 5: Tạo chứng chỉ PEM từ chứng chỉ PFX
RUN openssl pkcs12 -in /app/your_certificate.pfx -out /app/your_certificate.pem -nodes -passin pass:$SSL_PASSWORD

# Bước 6: Cài đặt ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore 
RUN dotnet build -c Release -o /app/build

# Bước 7: Publish ứng dụng
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# Bước 8: Build ứng dụng cuối cùng
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY your_certificate.pem /https/your_certificate.pem
ENTRYPOINT ["dotnet", "website_CLB_HTSV.dll"]
