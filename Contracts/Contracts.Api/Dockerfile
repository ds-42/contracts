#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Contracts.Api/Contracts.Api.csproj", "Contracts.Api/"]
COPY ["Contracts.Application/Contracts.Application.csproj", "Contracts.Application/"]
COPY ["Contracts.Domain/Contracts.Domain.csproj", "Contracts.Domain/"]
COPY ["Core.Users.Domain/Core.Users.Domain.csproj", "Core.Users.Domain/"]
COPY ["Core.Application/Core.Application.csproj", "Core.Application/"]
COPY ["Core.Auth.Application/Core.Auth.Application.csproj", "Core.Auth.Application/"]
COPY ["Core.Api/Core.Api.csproj", "Core.Api/"]
COPY ["Core.Auth.Api/Core.Auth.Api.csproj", "Core.Auth.Api/"]
COPY ["Infrastructure.Persistence/Infrastructure.Persistence.csproj", "Infrastructure.Persistence/"]
COPY ["Auth.Domain/Auth.Domain.csproj", "Auth.Domain/"]
RUN dotnet restore "./Contracts.Api/./Contracts.Api.csproj"
COPY . .
WORKDIR "/src/Contracts.Api"
RUN dotnet build "./Contracts.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Contracts.Api.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contracts.Api.dll"]