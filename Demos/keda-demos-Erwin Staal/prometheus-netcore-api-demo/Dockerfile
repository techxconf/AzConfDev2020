FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["CoreWebHttpRequestDurations_2.0.csproj", "./"]
RUN dotnet restore "./CoreWebHttpRequestDurations_2.0.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CoreWebHttpRequestDurations_2.0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoreWebHttpRequestDurations_2.0.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreWebHttpRequestDurations.dll"]
