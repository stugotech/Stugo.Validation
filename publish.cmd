@echo off

echo Uploading package to NuGet feed
.\build\NuGet\NuGet.exe push Stugo.Validation\bin\Release\*.nupkg