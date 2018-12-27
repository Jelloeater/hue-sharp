FROM microsoft/dotnet:2.1-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY HueSharp.csproj ./
RUN dotnet restore HueSharp.csproj
COPY . .
WORKDIR /src/
RUN dotnet build HueSharp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish HueSharp.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "hue-sharp.dll","-w"]