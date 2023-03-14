FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/Presentation/WebApi/WebApi.csproj", "Src/Presentation/WebApi/"]
COPY ["Src/Infrastructure/Infrastructure/Infrastructure.csproj", "Src/Infrastructure/Infrastructure/"]
COPY ["Src/Application/Application/Application.csproj", "Src/Application/Application/"]
COPY ["Src/Domain/Domain/Domain.csproj", "Src/Domain/Domain/"]
RUN dotnet restore "Src/Presentation/WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/Src/Presentation/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
