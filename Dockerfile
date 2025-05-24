# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY ByBitIntegration.sln ./
COPY ByBit/ByBit.csproj ByBit/
COPY MyProject.Domain/MyProject.Domain.csproj MyProject.Domain/
COPY Bybit.Tests/Bybit.Tests.csproj Bybit.Tests/
RUN dotnet restore

# copy the source code
COPY . .

# run unit tests
RUN dotnet test --no-build --verbosity normal

# publish the application
RUN dotnet publish ByBit/ByBit.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ByBit.dll"]
