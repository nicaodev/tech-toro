#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["checkingAccountAmount/checkingAccountAmount.API.csproj", "checkingAccountAmount/"]
COPY ["checkingAccountAmount.Application/checkingAccountAmount.Application.csproj", "checkingAccountAmount.Application/"]
COPY ["checkingAccountAmount.Domain/checkingAccountAmount.Domain.csproj", "checkingAccountAmount.Domain/"]
COPY ["checkingAccountAmount.Infra.IoC/checkingAccountAmount.Infra.IoC.csproj", "checkingAccountAmount.Infra.IoC/"]
COPY ["checkingAccountAmount.Infra.Data/checkingAccountAmount.Infra.Data.csproj", "checkingAccountAmount.Infra.Data/"]
RUN dotnet restore "checkingAccountAmount/checkingAccountAmount.API.csproj"
COPY . .
WORKDIR "/src/checkingAccountAmount"
RUN dotnet build "checkingAccountAmount.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "checkingAccountAmount.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "checkingAccountAmount.API.dll"]