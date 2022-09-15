#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/UserServices/UserServices.csproj", "src/UserServices/"]
RUN dotnet restore "src/UserServices/UserServices.csproj"
COPY . .
WORKDIR "/src/src/UserServices"
RUN dotnet build "UserServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserServices.dll"]