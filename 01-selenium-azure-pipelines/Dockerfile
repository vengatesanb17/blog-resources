FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["StudentManagement/StudentManagement.csproj", "StudentManagement/"]
RUN dotnet restore "StudentManagement/StudentManagement.csproj"
COPY . .
WORKDIR "/src/StudentManagement"
RUN dotnet build "StudentManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentManagement.dll"]
