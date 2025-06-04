# pokalaashokkumar.me

This repository hosts a portfolio website and example .NET projects.

## Projects

- `EnterpriseApi` - ASP.NET Core Web API skeleton with EF Core and JWT authentication.
- `DotNetInterviewProblems` - Console application with sample solutions for LeetCode problems.

Each project can be built with the .NET 8 SDK:

```bash
# build a project
cd <ProjectName>
dotnet build
```

## Running Tests

Make sure the .NET 8 SDK is installed. Run the unit tests with:

```bash
dotnet test DotNetInterviewProblems.Tests/DotNetInterviewProblems.Tests.csproj -v minimal
```
