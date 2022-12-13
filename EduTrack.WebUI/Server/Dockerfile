#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EduTrack.WebUI/Server/EduTrack.WebUI.Server.csproj", "EduTrack.WebUI/Server/"]
COPY ["EduTrack.Application/EduTrack.Application.csproj", "EduTrack.Application/"]
COPY ["EduTrack.Domain/EduTrack.Domain.csproj", "EduTrack.Domain/"]
COPY ["EduTrack.Localization/EduTrack.Localization.csproj", "EduTrack.Localization/"]
COPY ["EduTrack.Infrastracture/EduTrack.Infrastracture.csproj", "EduTrack.Infrastracture/"]
COPY ["EduTrack.WebUI/Client/EduTrack.WebUI.Client.csproj", "EduTrack.WebUI/Client/"]
COPY ["EduTrack.Client.HttpServices/EduTrack.WebUI.Client.HttpServices.csproj", "EduTrack.Client.HttpServices/"]
COPY ["EduTrack.WebUI/Shared/EduTrack.WebUI.Shared.csproj", "EduTrack.WebUI/Shared/"]
RUN dotnet restore "EduTrack.WebUI/Server/EduTrack.WebUI.Server.csproj"
COPY . .
WORKDIR "/src/EduTrack.WebUI/Server"
RUN dotnet build "EduTrack.WebUI.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EduTrack.WebUI.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EduTrack.WebUI.Server.dll"]