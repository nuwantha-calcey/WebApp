#!/bin/bash

for csprojFile in $(find . -type f -name "*.csproj"); do
    echo "Building $csprojFile"
    dotnet build "$csprojFile" --configuration Release
done