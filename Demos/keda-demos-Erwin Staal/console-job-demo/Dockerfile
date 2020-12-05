FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["consolejob.csproj", "./"]
RUN dotnet restore "./consolejob.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "consolejob.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "consolejob.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "consolejob.dll"]
