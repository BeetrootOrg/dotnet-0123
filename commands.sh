dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet new tool-manifest
dotnet tool install --local dotnet-ef
dotnet ef migrations add Initial
dotnet ef database update