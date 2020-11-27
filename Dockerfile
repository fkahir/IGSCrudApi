FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["IGSCrud/IGSCrud.csproj", "IGSCrud/"]
COPY ["IGSCrud.Application/IGSCrud.Application.csproj", "IGSCrud.Application/"]
COPY ["IGSCrud.Persistence/IGSCrud.Persistence.csproj", "IGSCrud.Persistence/"]
RUN dotnet restore "IGSCrud/IGSCrud.csproj"

COPY . .
WORKDIR "/src/IGSCrud"
RUN dotnet build "IGSCrud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IGSCrud.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IGSCrud.dll"]
