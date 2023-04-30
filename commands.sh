dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet new tool-manifest
dotnet tool install --local dotnet-ef
dotnet ef dbcontext scaffold "User ID=postgres;Password=postgres123;Host=localhost;Port=5432;Database=library_domain;" Npgsql.EntityFrameworkCore.PostgreSQL --context LibraryContext --context-dir DbContexts --output-dir Models
