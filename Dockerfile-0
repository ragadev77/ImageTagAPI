# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
#FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./ImageTagAPI/ImageTagAPI.csproj" --disable-parallel
RUN dotnet publish "./ImageTagAPI/ImageTagAPI.csproj" -c release -o /app --no-restore
#RUN dotnet publish "./ImageTagAPI/ImageTagAPI.csproj" -c release -o /app 

# Serve Stage
#FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 7000

ENTRYPOINT ["dotnet", "ImageTagAPI.dll"]
