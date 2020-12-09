FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Primeiro.csproj", "./"]
RUN dotnet restore "Primeiro.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Primeiro.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Primeiro.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Primeiro.dll"]

#docker run -it -p 5000:5000 primeiro
#docker run -it -p [porta inical]:[portafinal] [nomeimagem]
#Para rodar => ctrl + P e build da imagem