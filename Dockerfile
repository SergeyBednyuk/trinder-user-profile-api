# Stage 1: The 'build' stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# --- Caching Optimization: Copy project and solution files FIRST ---

# Copy the solution file, which is inside the 'trinder-user-profile-api' folder
COPY ["trinder-user-profile-api/trinder-user-profile-api.sln", "trinder-user-profile-api/"]

# Copy the API project file. The .csproj is DIRECTLY inside the 'trinder-user-profile-api' folder.
COPY ["trinder-user-profile-api/Trinder.UserProfile.API.csproj", "trinder-user-profile-api/"]

# Copy the other project files. These are at the root.
COPY ["Trinder.UserProfile.Application/Trinder.UserProfile.Application.csproj", "Trinder.UserProfile.Application/"]
COPY ["Trinder.UserProfile.Domain/Trinder.UserProfile.Domain.csproj", "Trinder.UserProfile.Domain/"]
COPY ["Trinder.UserProfile.Infrastructure/Trinder.UserProfile.Infrastructure.csproj", "Trinder.UserProfile.Infrastructure/"]

# Restore all NuGet packages for the entire solution.
RUN dotnet restore "trinder-user-profile-api/trinder-user-profile-api.sln"

# --- Main Build: Copy the rest of the source code and publish ---
COPY . .
# Publish the API project using its correct, simpler path.
RUN dotnet publish "trinder-user-profile-api/Trinder.UserProfile.API.csproj" -c Release -o /app/publish --no-restore

# Stage 2: The 'final' stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Trinder.UserProfile.API.dll"]