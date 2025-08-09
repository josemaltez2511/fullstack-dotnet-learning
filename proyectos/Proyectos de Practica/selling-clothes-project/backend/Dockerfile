# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src/SellingClothesBackend

COPY ["SellingClothesBackend/SellingClothesBackend.csproj", "./"]
RUN dotnet restore "./SellingClothesBackend.csproj"

COPY SellingClothesBackend/ ./
RUN dotnet publish "./SellingClothesBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "SellingClothesBackend.dll"]
