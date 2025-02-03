# ========= BUILD STAGE =========
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the .csproj file and restore dependencies (cache optimization)
COPY src/Bot.Telegram/Bot.Telegram.csproj src/Bot.Telegram/
RUN dotnet restore src/Bot.Telegram/Bot.Telegram.csproj

# Copy the rest of the source code
COPY src/Bot.Telegram/ src/Bot.Telegram/

# Set the working directory to the bot project and build the app
WORKDIR /app/src/Bot.Telegram
RUN dotnet publish Bot.Telegram.csproj -c Release -o /app/out --no-restore

# ========= RUNTIME STAGE =========
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/out ./

# Set the entry point
ENTRYPOINT ["dotnet", "SplitSage.Bot.Telegram.dll"]