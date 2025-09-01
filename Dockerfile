# Stage 1: The 'build' stage - where we compile your application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the solution file first. This path is correct.
COPY ["trinder-user-profile-api/trinder-user-profile-api.sln", "trinder-user-profile-api/"]

# Copy all the .csproj files for all projects.
# CORRECTED PATH for the API project is here.
COPY ["trinder-user-profile-api/Trinder.UserProfile.API/Trinder.UserProfile.API.csproj", "Trinder.UserProfile.API/"]
COPY ["Trinder.UserProfile.Application/Trinder.UserProfile.Application.csproj", "Trinder.UserProfile.Application/"]
COPY ["Trinder.UserProfile.Domain/Trinder.UserProfile.Domain.csproj", "Trinder.UserProfile.Domain/"]
COPY ["Trinder.UserProfile.Infrastructure/Trinder.UserProfile.Infrastructure.csproj", "Trinder.UserProfile.Infrastructure/"]

# Restore all NuGet packages for the entire solution. This path is correct.
RUN dotnet restore "trinder-user-profile-api/trinder-user-profile-api.sln"

# Copy the rest of the source code into the container.
COPY . .

# Publish the API project, creating a release-ready build.
# CORRECTED PATH for publishing the API project is here.
RUN dotnet publish "trinder-user-profile-api/Trinder.UserProfile.API/Trinder.UserProfile.API.csproj" -c Release -o /app/publish

# Stage 2: The 'final' stage - where we run your application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 8080 for the application
EXPOSE 8080

# The entrypoint command that starts your application.
ENTRYPOINT ["dotnet", "Trinder.UserProfile.API.dll"]