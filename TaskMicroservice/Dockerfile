FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaskMicroservice/TaskMicroservice.csproj", "TaskMicroservice/"]
RUN dotnet restore "TaskMicroservice/TaskMicroservice.csproj"
COPY . .
WORKDIR "/src/TaskMicroservice"
RUN dotnet build "TaskMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskMicroservice.dll"]
