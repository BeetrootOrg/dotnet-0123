dotnet new sln -n PersonsSite
dotnet new mvc -n PersonsSite
dotnet sln add PersonsSite/PersonsSite.csproj
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet new tool-manifest
dotnet tool install --local dotnet-ef
dotnet ef migrations add Initial
dotnet ef database update
dotnet tool install --local dotnet-aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator view Index List -m Person -outDir Views/Person -l _Layout --referenceScriptLibraries
dotnet aspnet-codegenerator view Create Create -m Person -outDir Views/Person -l _Layout --referenceScriptLibraries