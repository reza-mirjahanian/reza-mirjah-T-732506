FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Maximum/Maximum.csproj", "Maximum/"]
RUN dotnet restore "Maximum/Maximum.csproj"
COPY . .
WORKDIR "/src/Maximum"
RUN dotnet build "Maximum.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Maximum.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Maximum.dll"]
