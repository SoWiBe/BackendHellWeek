FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaskMicro/TaskMicro.csproj", "TaskMicro/"]
RUN dotnet restore "TaskMicro/TaskMicro.csproj"
COPY . .
WORKDIR "/src/TaskMicro"
RUN dotnet build "TaskMicro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskMicro.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskMicro.dll"]
