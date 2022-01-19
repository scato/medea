FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /Medea
COPY . .
WORKDIR /Medea/Test
RUN dotnet restore

ENTRYPOINT ["dotnet", "test"]
