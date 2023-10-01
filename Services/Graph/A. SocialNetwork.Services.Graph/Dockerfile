#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Graph/A. SocialNetwork.Services.Graph/A. SocialNetwork.Services.Graph.csproj", "Services/Graph/A. SocialNetwork.Services.Graph/"]
COPY ["Shared/SocialNetwork.Shared/SocialNetwork.Shared.csproj", "Shared/SocialNetwork.Shared/"]
COPY ["Services/Graph/D. SocialNetwork.Services.Graph.Services/D. SocialNetwork.Services.Graph.Services.csproj", "Services/Graph/D. SocialNetwork.Services.Graph.Services/"]
COPY ["Services/Graph/C. SocialNetwork.Services.Graph.Repository/C. SocialNetwork.Services.Graph.Repository.csproj", "Services/Graph/C. SocialNetwork.Services.Graph.Repository/"]
COPY ["Services/Graph/B .SocialNetwork.Servicec.Graph.Core/B .SocialNetwork.Servicec.Graph.Core.csproj", "Services/Graph/B .SocialNetwork.Servicec.Graph.Core/"]
RUN dotnet restore "Services/Graph/A. SocialNetwork.Services.Graph/A. SocialNetwork.Services.Graph.csproj"
COPY . .
WORKDIR "/src/Services/Graph/A. SocialNetwork.Services.Graph"
RUN dotnet build "A. SocialNetwork.Services.Graph.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "A. SocialNetwork.Services.Graph.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "A. SocialNetwork.Services.Graph.dll"]