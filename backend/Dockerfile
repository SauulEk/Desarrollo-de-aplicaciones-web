# Stage 1: Build the application
# Use the SDK image to compile the code
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
# Replace 'YourProjectName.csproj' with your actual filename
COPY ["docugen/docugen.csproj", "docugen/"]
RUN dotnet restore "docugen/docugen.csproj"

# Copy the rest of the source code
COPY . .
WORKDIR "/src/docugen"

# Build and Publish
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Run the application
# Use the lighter ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Expose port 8080 (Default for .NET 8+)
EXPOSE 8080
ENTRYPOINT ["dotnet", "docugen.dll"]
