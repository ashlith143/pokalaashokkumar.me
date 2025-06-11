# Azure Functions

Interview questions focused on serverless development using Azure Functions.

### What is Azure Functions?
Azure Functions is a serverless compute service that lets you run small pieces of code on-demand without provisioning infrastructure. You pay only for the time your code runs.

### What are common triggers for an Azure Function?
Functions can be triggered by HTTP requests, timers, Azure Queue or Service Bus messages, Event Grid events, and more. The trigger defines how the function is invoked.

### How do you create an HTTP-triggered function in C#?
Use the Azure Functions template with an `HttpTrigger` attribute:
```csharp
public static class HelloFunc
{
    [FunctionName("HelloFunc")]
    public static IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        string name = req.Query["name"];
        return new OkObjectResult($"Hello {name}");
    }
}
```

### How does scaling work for Azure Functions?
In the Consumption plan, Azure automatically scales the number of function instances based on incoming events. There's no need to manage servers, but a cold start may occur when a new instance spins up.

### What is the difference between Consumption and Premium plans?
The Consumption plan bills based on execution time and scales to zero when idle. The Premium plan keeps instances warm for lower latency, supports VNET integration, and has predictable pricing.

### How can you share code or services across multiple functions?
You can place common logic in a shared class library and use dependency injection via the `FunctionsStartup` class to register services, similar to ASP.NET Core.

### When should you use Durable Functions?
Durable Functions extend Azure Functions with stateful workflows. They are useful for orchestrating long-running operations, such as chaining functions or running fan-out/fan-in patterns.

## Interview Questions

### What are Azure Functions?
Azure Functions is a serverless compute service that allows you to run small pieces of code in response to events without managing any infrastructure. You pay only for the time your code executes.

### How are Azure Functions different from WebJobs and Logic Apps?
- **WebJobs** run continuously or on a schedule inside an App Service.
- **Logic Apps** let you orchestrate workflows visually using built‑in connectors.
- **Azure Functions** are lightweight, event‑driven pieces of code that automatically scale and are billed per execution.

### Explain the different hosting plans for Azure Functions.
- **Consumption Plan** – auto scales on demand and you pay only for execution time but cold starts can occur.
- **Premium Plan** – pre‑warmed instances remove cold starts, supports VNET integration and advanced scaling.
- **Dedicated/App Service Plan** – runs on dedicated VMs with manual scaling similar to an App Service.

### What are triggers and bindings in Azure Functions?
A **trigger** defines how a function is invoked, for example an HTTP request or a timer. **Bindings** provide additional input or output sources such as blobs or queues.
```csharp
[FunctionName("HttpExample")]
public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req,
    [Blob("output-container/{rand-guid}", FileAccess.Write)] Stream outputBlob,
    ILogger log)
```

### How do you deploy an Azure Function?
Use Visual Studio or VS Code publishing, Azure CLI, ZIP deploy, Azure DevOps/GitHub Actions, or ARM templates for infrastructure as code.

### What is the difference between an HTTP trigger and a timer trigger?
An **HTTP trigger** runs when an HTTP request arrives, while a **timer trigger** executes on a schedule using a CRON expression.

### How do you secure an Azure Function?
- Function or host keys for simple authorization
- Azure AD authentication for OAuth flows
- Network restrictions or VNET integration
- Managed identities to access other Azure resources

### What is a function app?
A function app is a container for one or more related functions that share the same host, configuration and deployment settings.

### What is the difference between consumption and premium plans?
Consumption is pay‑per‑use with possible cold starts and no VNET support. Premium keeps instances warm, supports VNETs and offers dedicated scaling.

### How does scaling work in Azure Functions?
- **Consumption Plan** – scales automatically based on events.
- **Premium Plan** – pre‑warmed instances plus elastic scale.
- **Dedicated Plan** – scales like an App Service plan.

### What are durable functions?
Durable Functions let you create stateful workflows (chaining, fan‑out/fan‑in, human interaction) using code-based orchestration.

### How do you monitor and log Azure Functions?
Use Application Insights, log output through `ILogger`, Azure Monitor metrics, and streaming logs from the portal or CLI.

### How can you integrate Azure Functions with other services?
Bindings provide direct input or output to services like Cosmos DB or Service Bus. You can also call external APIs using SDKs or handle events via Event Grid.

### What are the limitations of Azure Functions?
Execution timeout on the Consumption plan, potential cold start latency, limited control over infrastructure and not ideal for very long-running tasks.

### Explain cold start in Azure Functions.
Cold start happens when a function instance must spin up from zero to handle a request. Premium and Dedicated plans keep instances warm to avoid this delay.

### How do you manage dependencies in Azure Functions?
Use NuGet packages in Visual Studio or VS Code. For script-based functions use the `#r` directive. Isolated process functions use regular project references.

### What are the supported languages for Azure Functions?
C#, JavaScript/TypeScript, Python, Java, PowerShell and custom handlers such as Go or Rust.

### What is the difference between in-process and isolated process hosting models?
In‑process runs your code in the same process as the runtime for faster cold starts. Isolated process runs in a separate worker for greater flexibility and isolation.

### How do you configure environment variables in Azure Functions?
Use `local.settings.json` locally and Application settings in the Azure portal. Access values with `Environment.GetEnvironmentVariable()`.

### What is the difference between function.json and host.json?
`function.json` configures bindings for a specific function while `host.json` provides global settings such as logging and retry policies for the entire function app.

## Scenario Questions

### Logging and troubleshooting
Enable Application Insights and use `ILogger` to trace processing steps. Inspect failures and performance in the portal and check for poison messages or dead‑letter queues.

### Partial updates in APIs
Implement an HTTP‑triggered function using `HttpPatch` and a JSON Patch document to update only the required fields of a resource.

### Implement rate limiting
Azure Functions itself lacks rate limiting. Put API Management in front of the function or store request counters in Redis and block requests that exceed your threshold.

### Chained workflows using Durable Functions
Use an orchestrator function that calls activity functions like `ValidateOrder`, `CheckInventory` and `ProcessPayment` in sequence.

### Secure external API calls
Store API keys in Azure Key Vault and access them using a managed identity rather than hardcoding credentials in code.

### Handling poison messages in queues
Set `MaxDeliveryCount` on the queue so failing messages are moved to the dead-letter queue. Process the DLQ separately and alert on high counts.

### Versioning HTTP APIs
Create versioned routes such as `/api/v1/customers` and `/api/v2/customers`, or use query string versioning. Document each version separately.

### Cold start concerns
Use the Premium plan for pre-warmed instances or keep a Consumption plan warm with a timer-triggered ping function.

### Cross-origin requests (CORS)
Configure CORS in the Function App settings or within your startup code so your function can be called from other domains.

**Best practices**: always use Application Insights, prefer Durable Functions for complex workflows, store secrets in Key Vault, use API Management for policies, and handle dead-letter queues.

## Debugging

### How do you debug an Azure Function locally?
Run the function host in Visual Studio or VS Code with F5, set breakpoints and use tools like Postman to invoke HTTP endpoints.

### What is the local.settings.json file?
It contains local configuration values such as connection strings and environment variables. This file is not deployed to Azure.

### How do you simulate triggers locally?
Invoke HTTP triggers with a browser or Postman and use Azurite or the Storage Emulator for queue messages. Timer triggers can include `RunOnStartup` to run immediately.

### Common local debugging issues
Port conflicts, missing dependencies or configuration mismatches between `local.settings.json` and Azure app settings can cause failures.

### Debugging isolated process
Attach the debugger to the worker process or run `dotnet run` in the worker directory for debugging.

### How can you debug a deployed Azure Function?
Use Application Insights, log streaming or attach a remote debugger from Visual Studio when running in Premium or Dedicated plans.

### Tools for real-time logs
The Azure portal Log Stream, Application Insights Live Metrics and `func azure functionapp logstream` provide real-time log output.

### Remote debugging challenges
Remote debugging can impact live users, is slower than local debugging and is only supported on Premium or Dedicated plans.

### Local works but fails in Azure
Check configuration values, connection strings and network restrictions in the Azure portal. Cold start delays may also occur on the first request.

### Scenario-based debugging
- **HTTP trigger returns 500 in Azure** – inspect Application Insights for the stack trace and verify app settings.
- **Queue trigger timeouts** – check the `host.json` timeout setting and analyze slow dependencies.
- **Missing environment variables** – ensure values are configured in the portal rather than only in `local.settings.json`.
- **Simulating Service Bus locally** – use Azurite for queues or an actual Service Bus namespace in dev.
- **Production hangs** – monitor Live Metrics and review dependency calls and retry policies.
