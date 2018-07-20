cd ..\TCApi 
dotnet restore
dotnet build -o ..\deploy
dotnet publish -o ..\deploy