#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProductRegistrationMongoDB/ProductRegistrationMongoDB.csproj", "ProductRegistrationMongoDB/"]
COPY ["ProductRegistrationMongoDB.Infra/ProductRegistrationMongoDB.Infra.csproj", "ProductRegistrationMongoDB.Infra/"]
COPY ["ProductRegistrationMongoDB.Domain/ProductRegistrationMongoDB.Domain.csproj", "ProductRegistrationMongoDB.Domain/"]
COPY ["ProductRegistrationMongoDB.Service/ProductRegistrationMongoDB.Service.csproj", "ProductRegistrationMongoDB.Service/"]
RUN dotnet restore "ProductRegistrationMongoDB/ProductRegistrationMongoDB.csproj"
COPY . .
WORKDIR "/src/ProductRegistrationMongoDB"
RUN dotnet build "ProductRegistrationMongoDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductRegistrationMongoDB.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductRegistrationMongoDB.dll"]