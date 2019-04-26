FROM mcr.microsoft.com/dotnet/core/sdk as build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o /app

ENTRYPOINT [ "dotnet", "Assignment7Test.dll" ]

