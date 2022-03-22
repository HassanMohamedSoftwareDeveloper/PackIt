#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PackIt.Api/PackIt.Api.csproj", "PackIt.Api/"]
COPY ["PackIt.Application/PackIt.Application.csproj", "PackIt.Application/"]
COPY ["PackIt.Domain/PackIt.Domain.csproj", "PackIt.Domain/"]
COPY ["PackIt.Shared.Abstractions/PackIt.Shared.Abstractions.csproj", "PackIt.Shared.Abstractions/"]
COPY ["PackIt.Shared/PackIt.Shared.csproj", "PackIt.Shared/"]
COPY ["PackIt.Infrasturcture/PackIt.Infrasturcture.csproj", "PackIt.Infrasturcture/"]
RUN dotnet restore "PackIt.Api/PackIt.Api.csproj"
COPY . .
WORKDIR "/src/PackIt.Api"
RUN dotnet build "PackIt.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PackIt.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PackIt.Api.dll"]