FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY KKday.B2D.Web.InternAgent.sln ./
COPY KKday.B2D.Web.InternAgent/KKday.B2D.Web.InternAgent.csproj KKday.B2D.Web.InternAgent/
RUN dotnet restore KKday.B2D.Web.InternAgent.sln

COPY KKday.B2D.Web.InternAgent/ KKday.B2D.Web.InternAgent/
RUN dotnet publish KKday.B2D.Web.InternAgent/KKday.B2D.Web.InternAgent.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "KKday.B2D.Web.InternAgent.dll"]
