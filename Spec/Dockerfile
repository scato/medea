FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /Medea
COPY . .
WORKDIR /Medea/Spec
RUN dotnet restore

ENTRYPOINT ["dotnet", "test"]
