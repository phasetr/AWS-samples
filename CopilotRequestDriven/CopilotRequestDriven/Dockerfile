FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CopilotRequestDriven/CopilotRequestDriven.csproj", "CopilotRequestDriven/"]
RUN dotnet restore "CopilotRequestDriven/CopilotRequestDriven.csproj"
COPY . .
WORKDIR "/src/CopilotRequestDriven"
RUN dotnet build "CopilotRequestDriven.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CopilotRequestDriven.csproj" -c Release -o /app/publish

FROM build as migration
ENV ASPNETCORE_ENVIRONMENT Staging
RUN dotnet tool restore \
    && dotnet dotnet-ef migrations bundle

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT Staging
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=migration /src/CopilotRequestDriven/efbundle .
ENTRYPOINT ["dotnet", "CopilotRequestDriven.dll"]
