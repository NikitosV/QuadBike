FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
#COPY ["QuadBike.Website/QuadBike.Website.csproj", "QuadBike.Website/"]
#COPY ["QuadBike.Logic/QuadBike.Logic.csproj", "QuadBike.Logic/"]
#COPY ["QuadBike.Model/QuadBike.Model.csproj", "QuadBike.Model/"]
#COPY ["QuadBike.Common/QuadBike.Common.csproj", "QuadBike.Common/"]
#COPY ["QuadBike.DataProvider/QuadBike.DataProvider.csproj", "QuadBike.DataProvider/"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet <AssemblyName>.dll
#RUN dotnet restore "QuadBike.Website/QuadBike.Website.csproj"
#COPY . .
#WORKDIR "/src/QuadBike.Website"
#RUN dotnet build "QuadBike.Website.csproj" -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish "QuadBike.Website.csproj" -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "QuadBike.Website.dll"]
#travis
#docker ps -a
#docker build -t 'id' . exec -it 'id' cmd
#
#app-veyor