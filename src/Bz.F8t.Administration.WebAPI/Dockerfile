#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Bz.F8t.Administration.WebAPI/Bz.F8t.Administration.WebAPI.csproj", "src/Bz.F8t.Administration.WebAPI/"]
COPY ["src/Bz.F8t.Administration.Application/Bz.F8t.Administration.Application.csproj", "src/Bz.F8t.Administration.Application/"]
COPY ["src/Bz.F8t.Administration.Domain/Bz.F8t.Administration.Domain.csproj", "src/Bz.F8t.Administration.Domain/"]
COPY ["src/Bz.F8t.Administration.Infrastructure/Bz.F8t.Administration.Infrastructure.csproj", "src/Bz.F8t.Administration.Infrastructure/"]
RUN dotnet restore "src/Bz.F8t.Administration.WebAPI/Bz.F8t.Administration.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Bz.F8t.Administration.WebAPI"
RUN dotnet build "Bz.F8t.Administration.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bz.F8t.Administration.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bz.F8t.Administration.WebAPI.dll"]