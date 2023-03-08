# README

## Connection String

### SQLite

```
  "ConnectionStrings": {
    "DefaultConnection": "DataSource=app.db;Cache=Shared"
  },
```

### PostgreSQL

```
  "ConnectionStrings": {
    "DefaultConnection": "User ID=user;Password=pass;Host=localhost;Port=5432;Database=mydb;"
  },
```

## commands

```shell
dotnet new tool-manifest
dotnet tool install dotnet-ef --version 6.0.14
```

```shell
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.14
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0.8
```

```shell
dotnet dotnet-ef migrations add AddUser
dotnet dotnet-ef database update
```
