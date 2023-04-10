dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet new tool-manifest
dotnet tool install --local dotnet-ef
dotnet ef dbcontext scaffold "User ID=user;Password=password;Host=localhost;Port=5432;Database=shop;" Npgsql.EntityFrameworkCore.PostgreSQL --context ShopContext --context-dir DbContexts --output-dir Models