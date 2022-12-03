FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WeeksMicroservice/WeeksMicroservice.csproj", "WeeksMicroservice/"]
RUN dotnet restore "WeeksMicroservice/WeeksMicroservice.csproj"
COPY . .
WORKDIR "/src/WeeksMicroservice"
RUN dotnet build "WeeksMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeeksMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeeksMicroservice.dll"]
