# ASP.NET Core

Questions covering ASP.NET Core with practical examples.

## General & Core Concepts

### What is .NET Core? How is it different from .NET Framework?
.NET Core is a cross-platform, open-source runtime for building modern apps.  
It separates from the Windows-only .NET Framework and runs on Linux and macOS.

### What are the advantages of using .NET Core?
- Cross-platform support
- Improved performance and modularity
- Side-by-side versioning so each app uses its own runtime

### What are the main components of .NET Core?
The **runtime** executes code, the **BCL** provides the base class libraries,
and the **SDK** includes tools like the CLI and MSBuild for building apps.

### What is the difference between .NET Core and .NET 5/6/7+ (now .NET)?
.NET 5 and later unify the .NET platform under a single name: ".NET".
They build on .NET Core and replace the old framework going forward.

### Explain the difference between SDK and Runtime in .NET Core.
The *runtime* contains only what is needed to run apps, while the *SDK*
includes compilers and CLI tools for development.

## Project Structure & Configuration

### What is the purpose of the Program.cs and Startup.cs files?
`Program.cs` creates the host and configures services. In older templates,
`Startup.cs` separated service registration (`ConfigureServices`) from the HTTP
pipeline configuration (`Configure`).

### What is the role of the appsettings.json file?
It stores configuration values such as connection strings. Environment specific
files like `appsettings.Development.json` override values when running in that
environment.

### How do you read configurations from appsettings.json?
Use the `Configuration` API injected via `IConfiguration`. Example:

```csharp
var key = _config["Jwt:Key"];
```

### How do you add environment-specific configurations?
Files named `appsettings.{Environment}.json` are loaded automatically when the
`ASPNETCORE_ENVIRONMENT` variable is set.

## Dependency Injection (DI)

### What is Dependency Injection? Why is it important?
DI provides class dependencies from a container instead of creating them
manually. This promotes loose coupling and easier testing.

### What are the different lifetimes in DI? (Transient, Scoped, Singleton)
- **Transient**: new instance for every request
- **Scoped**: one instance per HTTP request
- **Singleton**: one instance for the application's lifetime

### How do you register a service in the DI container?
Call `AddTransient`, `AddScoped`, or `AddSingleton` in `Program.cs` or
`Startup.cs`.

### How do you inject dependencies in a controller or a class?
Declare them in the constructor and they are provided automatically by the
container.

## Middleware

### What is Middleware in .NET Core?
Middleware components process requests and responses in a pipeline, allowing you
to add cross-cutting concerns like logging or authentication.

### How do you create a custom middleware?
Create a class with an `Invoke` or `InvokeAsync` method that accepts
`HttpContext`. Register it in the pipeline with `app.UseMiddleware<MyMiddleware>`.

### Explain the order of middleware execution in the pipeline.
Middleware runs in the order it is added. Each component can decide whether to
call the next delegate. Order matters for correct behavior.

### What is the purpose of Use, Run, and Map in middleware?
`Use` adds middleware that can call `next`. `Run` is a terminal delegate that
does not call the next middleware. `Map` branches the pipeline based on a path.

## Controllers & Routing

### How does routing work in .NET Core?
Routing matches the incoming URL to route templates defined via attributes or
conventions and then invokes the corresponding controller action.

### What are the differences between attribute routing and conventional routing?
Attribute routing uses attributes directly on actions, while conventional
routing defines patterns in one place (typically `Program.cs`). Attribute
routing offers more control per action.

### What is the purpose of the [ApiController] attribute?
It enables automatic model validation and binding behavior tailored for APIs,
such as returning `400 Bad Request` when model state is invalid.

### What is model binding and model validation?
Model binding maps request data to action parameters. Validation attributes
check that the bound data meets required rules before the action executes.

## Web APIs & REST

### How do you create a Web API in .NET Core?
Create a controller that derives from `ControllerBase` and use `[HttpGet]`,
`[HttpPost]`, etc. Endpoints return objects which are serialized as JSON.

### What is the difference between IActionResult and ActionResult<T>?
`IActionResult` is a general result type, while `ActionResult<T>` combines that
with a specific return type for convenience and automatic 200 responses.

### How do you handle HTTP status codes in APIs?
Return helper methods like `Ok()`, `NotFound()`, or `StatusCode(500)` to produce
the correct status code and body.

### How do you enable CORS in a .NET Core application?
Call `services.AddCors` in `Program.cs` and add `app.UseCors` specifying allowed
origins, headers, and methods.

### What is the difference between HttpGet, HttpPost, HttpPut, HttpDelete, and HttpPatch?
These attributes map actions to HTTP verbs. `HttpPatch` is used for partial
updates with JSON Patch, while the others correspond to standard CRUD verbs.

### How do you handle partial updates using HttpPatch in .NET Core? (JSON Patch)
Use the `Microsoft.AspNetCore.JsonPatch` package and accept a `JsonPatchDocument`
parameter. Apply it to the entity and validate before saving.

## Entity Framework Core (EF Core)

### What is EF Core? How is it different from EF 6?
EF Core is a lightweight, cross-platform ORM. It supports LINQ queries,
change tracking, and migrations. It drops some EF6 features but adds new ones
like batching and better performance.

### What are migrations in EF Core?
Migrations keep the database schema in sync with model classes. They track
incremental changes over time.

### How do you create and apply migrations?
Run `dotnet ef migrations add <Name>` to scaffold a migration and
`dotnet ef database update` to apply it.

### Explain the difference between DbContext and DbSet.
`DbContext` represents a session with the database. `DbSet` represents a table
and provides methods for querying and saving instances of an entity type.

### What is Lazy Loading and Eager Loading?
Lazy loading loads related data when it is first accessed. Eager loading uses
`Include` to load related data with the initial query.

## Authentication & Authorization

### What is the difference between Authentication and Authorization?
Authentication verifies a user's identity; authorization determines what the
user is allowed to do.

### How do you implement JWT-based authentication in .NET Core?
Add JWT bearer authentication in `Program.cs` and validate tokens with a secret
key. Clients obtain a token after login and send it in the `Authorization`
header.

### What are policies and claims-based authorization?
Policies allow complex rules based on user claims. Claims represent user data
like role or age and are evaluated by the policy provider.

### How do you secure APIs using role-based authorization?
Add `[Authorize(Roles = "Admin")]` attributes or policy checks in controllers to
restrict access.

## Error Handling & Logging

### How do you handle errors in a .NET Core application?
Use exception-handling middleware such as `UseExceptionHandler` in production
and `UseDeveloperExceptionPage` in development.

### What is the Developer Exception Page?
It shows detailed stack traces during development to aid debugging. It should be
disabled in production.

### How do you log errors in .NET Core?
Use the `ILogger` interface or Serilog. Logs can be written to console, files,
or external services.

### What are built-in logging providers in .NET Core?
Console, Debug, EventSource, and EventLog (Windows) are available out of the box.

## Performance, Rate Limiting & Best Practices

### How do you improve performance in a .NET Core application?
Use async APIs, minimize allocations, and enable response caching or output
caching. Measure with profiling tools.

### What are asynchronous programming practices in .NET Core?
Prefer `async`/`await` for I/O operations and return `Task` or `Task<T>` from
APIs to avoid blocking threads.

### What is the difference between synchronous and asynchronous controllers?
Asynchronous controllers return `Task` and allow the server to free up threads
while awaiting I/O operations.

### What are the benefits of using IAsyncEnumerable in APIs?
It streams results to the client without allocating the entire collection in
memory, improving scalability.

### How do you implement caching in .NET Core?
Use `IMemoryCache` or `IDistributedCache` to store data. Response caching can be
enabled with middleware and the `[ResponseCache]` attribute.

### How do you implement rate limiting in a .NET Core API?
Middleware or libraries like `AspNetCoreRateLimit` can track requests per user
or IP and reject excess calls with a 429 status.

## API Versioning & Routing

### What is API versioning? Why is it important?
It allows you to evolve APIs without breaking existing clients. Versioning makes
changes explicit and controlled.

### How do you implement API versioning in .NET Core? (Query string, URL path, HTTP header)
Use the `Asp.Versioning.Http` package to specify versions via query parameters,
URL segments, or headers like `api-version`.

### What are the different strategies for API versioning routing?
Version can be part of the URL, query string, header, or media type. Choose the
approach that suits your API consumers.

### How do you ensure backward compatibility while using versioning?
Keep old controllers and routes functional while adding new versions. Deprecate
features gradually.

## Filters

### What are filters in .NET Core? What are the different types?
Filters run before or after action methods and can handle cross-cutting
concerns. Types include action, result, exception, and authorization filters.

### Explain how Action Filters, Result Filters, Exception Filters, and Authorization Filters work.
Action filters run before and after actions. Result filters run around result
execution. Exception filters catch unhandled exceptions. Authorization filters
determine access rights.

### How do you create a custom filter?
Implement the appropriate filter interface, such as `IActionFilter`, and
register it globally or on specific controllers.

## Advanced & Real-world Scenarios

### How do you deploy a .NET Core application to IIS, Azure, or Linux?
Publish the app using `dotnet publish` and configure IIS or a reverse proxy like
Nginx. Azure App Service and containers are also common deployment targets.

### What is Kestrel? How does it work with reverse proxies?
Kestrel is the cross-platform web server built into ASP.NET Core. In production
it's often run behind IIS, Nginx, or Apache, which handle SSL termination and
forward requests to Kestrel.

### How do you configure HTTPS and SSL in a .NET Core app?
Use `UseHttpsRedirection` and configure certificates in `appsettings.json` or
with environment variables.

### How does .NET Core handle cross-platform development?
The runtime, tools, and libraries work the same on Windows, Linux, and macOS,
allowing you to develop and deploy on any of them.

### How do you manage secrets and sensitive data in .NET Core?
Use Secret Manager in development and environment variables or Azure Key Vault
in production to avoid storing secrets in source control.

## Versioning & Updates

### How do you upgrade a .NET Core app to the latest .NET version?
Update the target framework in the project file, upgrade NuGet packages, and run
tests to verify compatibility.

### How do you manage backward compatibility in APIs?
Maintain versioned endpoints and provide clear deprecation timelines so clients
can migrate gradually.


### How does middleware work in ASP.NET Core?
Middleware components are executed in a pipeline. Each component can handle or pass on the HTTP request. For instance, authentication middleware checks credentials before MVC middleware routes the request to a controller.

### What is dependency injection and why is it used?
ASP.NET Core has built-in dependency injection (DI). DI promotes loose coupling by providing required services to classes via constructors. This makes controllers easier to test and maintain.

### What is the purpose of the `appsettings.json` file?
It contains configuration values that are loaded at runtime. You can provide environment-specific settings using files like `appsettings.Development.json`.

### How do you configure logging in ASP.NET Core?
Use the logging APIs in `Program.cs` to add providers such as Console or Application Insights. Logging levels can be controlled in configuration.

### What is the difference between `Use` and `Run` when adding middleware?
`Use` can invoke the next delegate in the pipeline, while `Run` terminates the pipeline and prevents further middleware from executing.

### What is the difference between `AddSingleton` and `AddTransient`?
`AddSingleton` registers one instance of a service for the entire application lifetime, while `AddTransient` creates a new instance each time it is requested. Use singletons for shared, stateless services and transients for lightweight, disposable ones.

### How do you secure an API using JWT authentication?
Configure JWT bearer authentication in `Program.cs` and issue tokens to clients upon login. Clients include the token in the `Authorization` header so middleware can validate and authorize requests.

