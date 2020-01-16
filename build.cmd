
set version=%1
set key=%2

cd %~dp0

dotnet build magic.lambda.config/magic.lambda.config.csproj --configuration Release --source https://api.nuget.org/v3/index.json
dotnet nuget push magic.lambda.config/bin/Release/magic.lambda.config.%version%.nupkg -k %key% -s https://api.nuget.org/v3/index.json
