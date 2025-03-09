FROM node:20-alpine AS nodestage
WORKDIR /src/ClientApp
COPY ngLifeCounter.Code/ClientApp/. .
RUN npm install

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ngLifeCounter.Code/ngLifeCounter.MVC.csproj", "ngLifeCounter.Code/"]
COPY ["ngLifeCounter.Backend/ngLifeCounter.Backend.csproj", "ngLifeCounter.Backend/"]
COPY ["ngLifeCounter.Constants/ngLifeCounter.Constants.csproj", "ngLifeCounter.Constants/"]
COPY ["ngLifeCounter.Models/ngLifeCounter.Models.csproj", "ngLifeCounter.Models/"]
COPY ["ngLifeCounter.Data/ngLifeCounter.Data.csproj", "ngLifeCounter.Data/"]
COPY ["ngLifeCounter.EmailSender/ngLifeCounter.EmailSender.csproj", "ngLifeCounter.EmailSender/"]
COPY ["ngLifeCounter.Security/ngLifeCounter.Security.csproj", "ngLifeCounter.Security/"]

# Add npm and node in build stage to run npm install
RUN apt-get update && apt-get install -y npm

RUN dotnet restore "ngLifeCounter.Code/ngLifeCounter.MVC.csproj"
COPY . .

RUN dotnet build "ngLifeCounter.Code/ngLifeCounter.MVC.csproj" -c Release -o /app/build

# Copy the /src/ClientApp from nodestage above to wwwroot
COPY --from=nodestage /src/ClientApp wwwroot/

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
RUN dotnet publish "ngLifeCounter.Code/ngLifeCounter.MVC.csproj" -c Release -o /app/publish /p:EnvironmentName=QA

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ngLifeCounter.MVC.dll"]

#ECECUTE THIS IN CMD TO RUN DOCKER IMAGE
#docker run -p 803:8080 -e ASPNETCORE_ENVIRONMENT=qa nglifecounter:latest