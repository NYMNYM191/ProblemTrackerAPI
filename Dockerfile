# ใช้ .NET 8.0 SDK สร้าง
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY . .

# Restore NuGet packages
RUN dotnet restore

# ติดตั้ง EntityFrameworkCore เพิ่ม
RUN dotnet add ProblemTrackerAPI/ProblemTrackerAPI.csproj package Microsoft.EntityFrameworkCore --version 9.0.4

# แล้วค่อย Build
RUN dotnet build -c Release -o /app/build

# Publish
RUN dotnet publish -c Release -o /app/publish

# Runtime container
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ProblemTrackerAPI.dll"]