#!/bin/sh

./src/API/SFC.Team.Api/entrypoint.Common.sh
dotnet run --project /app/src/API/SFC.Team.Api/SFC.Team.Api.csproj --no-launch-profile