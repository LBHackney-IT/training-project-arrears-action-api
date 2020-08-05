FROM mcr.microsoft.com/dotnet/core/sdk:2.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./ArrearsActionAPI.sln ./
COPY ./ArrearsActionAPI/ArrearsActionAPI.csproj ./ArrearsActionAPI/
COPY ./ArrearsActionAPI.UnitTests/ArrearsActionAPI.UnitTests.csproj ./ArrearsActionAPI.UnitTests/

RUN dotnet restore ./ArrearsActionAPI/ArrearsActionAPI.csproj
RUN dotnet restore ./ArrearsActionAPI.UnitTests/ArrearsActionAPI.UnitTests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out ArrearsActionAPI.UnitTests/ArrearsActionAPI.UnitTests.csproj

CMD dotnet test
