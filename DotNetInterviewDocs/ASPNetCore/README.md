# ASP.NET Core

Questions covering ASP.NET Core with practical examples.

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
