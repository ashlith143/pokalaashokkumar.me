# EnterpriseApi

This is a sample ASP.NET Core Web API using Entity Framework Core with SQL Server, JWT based authentication and Serilog logging.

## Building

Requires the .NET 6 SDK to be installed.

```bash
dotnet restore
dotnet build
```

## Running

```
dotnet run --project EnterpriseApi.csproj
```

Update `appsettings.json` with your SQL Server connection string and JWT parameters.
