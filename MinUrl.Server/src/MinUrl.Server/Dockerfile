FROM mcr.microsoft.com/dotnet/sdk:10.0 AS publish
WORKDIR /app
ARG BUILD_CONFIGURATION=Release
COPY . ./
RUN dotnet restore
RUN dotnet tool install --global dotnet-ef

ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
COPY --from=publish /root/.local/share/MinUrl /root/.local/share/MinUrl 
ENTRYPOINT ["dotnet", "MinUrl.Server.dll"]