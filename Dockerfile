FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore -s https://api.nuget.org/v3/index.json --packages packages --ignore-failed-sources

COPY . ./
RUN dotnet publish -c Release -o out

# Install dotnet dump tool
RUN dotnet tool install --global dotnet-dump

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

# Add the following lines to grant root permissions
USER root

LABEL io.k8s.display-name="app name" \
      io.k8s.description="container description..." \
      io.openshift.expose-services="8080:http"

EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "Deployment.dll"]
