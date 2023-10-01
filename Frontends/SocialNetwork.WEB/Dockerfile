#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Frontends/SocialNetwork.WEB/SocialNetwork.WEB.csproj", "Frontends/SocialNetwork.WEB/"]
COPY ["Frontends/SocialNetwork.WEB.Service/SocialNetwork.WEB.Service.csproj", "Frontends/SocialNetwork.WEB.Service/"]
COPY ["Shared/SocialNetwork.Shared/SocialNetwork.Shared.csproj", "Shared/SocialNetwork.Shared/"]
COPY ["Frontends/SocialNetwork.WEB.Data/SocialNetwork.WEB.Data.csproj", "Frontends/SocialNetwork.WEB.Data/"]
COPY ["Frontends/SocialNetwork.WEB.Core/SocialNetwork.WEB.Core.csproj", "Frontends/SocialNetwork.WEB.Core/"]
RUN dotnet restore "Frontends/SocialNetwork.WEB/SocialNetwork.WEB.csproj"
COPY . .
WORKDIR "/src/Frontends/SocialNetwork.WEB"
RUN dotnet build "SocialNetwork.WEB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SocialNetwork.WEB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SocialNetwork.WEB.dll"]