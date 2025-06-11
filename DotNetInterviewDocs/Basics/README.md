# Basics

Sample questions covering fundamental .NET concepts.

### What is the CLR?
The Common Language Runtime (CLR) is the virtual machine component of .NET that manages code execution, memory, and type safety.

### Explain boxing and unboxing.
Boxing converts a value type to an object on the heap. Unboxing extracts the value type back from the object. Excessive boxing can lead to performance overhead.

### How does garbage collection work in .NET?
The CLR automatically frees memory for objects that are no longer referenced. The garbage collector runs periodically and compacts the heap to reduce fragmentation.

### What are value types and reference types?
Value types store data directly and are copied when passed to methods. Reference types store a pointer to data on the heap, so multiple references can point to the same object.

### What is the difference between `ref` and `out` parameters?
Both allow a method to modify the caller's variable. `ref` requires the variable to be initialized before passing, while `out` does not and must be assigned inside the method.

### What are generics and why are they useful?
Generics allow you to define type-safe data structures and methods. They reduce casting and increase code reusability, such as `List<T>` for strongly typed collections.

### What is a delegate in C#?
A delegate is a type that references a method with a specific signature. Delegates enable callback mechanisms and are the basis for events and LINQ projections.

## SOLID Principles

Software design guidelines created by Robert C. Martin to improve readability and maintainability.

### Single Responsibility Principle
Each class should handle one responsibility. For example, keep data access logic separate from business logic so each has only one reason to change.

### Open/Closed Principle
Classes should be open for extension but closed for modification. Interfaces or inheritance let you add new behavior without altering existing code.

### Liskov Substitution Principle
Subclasses must be usable anywhere their base class is expected without breaking functionality.

### Interface Segregation Principle
Avoid forcing consumers to depend on members they do not use. Split large interfaces into smaller ones.

### Dependency Inversion Principle
High-level modules should depend on abstractions, not on concrete implementations. Dependency injection helps achieve this separation.

## KISS – Keep It Simple, Stupid
Prefer simple, readable code over complex solutions. For instance, use case-insensitive comparisons instead of many `if` checks for different string values.

```csharp
// Bad
if (status == "Active" || status == "active" || status == "ACTIVE") { }

// Good
if (status.Equals("Active", StringComparison.OrdinalIgnoreCase)) { }
```

## DRY – Don’t Repeat Yourself
Extract duplicated logic into reusable methods or classes.

```csharp
// Bad
void SaveUser() { /* validation logic */ }
void UpdateUser() { /* same validation logic */ }

// Good
void ValidateUser(User user) { /* validation logic */ }
```

## YAGNI – You Aren't Gonna Need It
Only implement features when necessary to avoid over-complication.

## Lean Principles
Focus on eliminating waste and delivering small, high-quality increments quickly. Empower teams and view the system holistically.

## Separation of Concerns
Divide an application into sections that each address a distinct concern such as UI, business logic, and data access.

## Software Architecture Styles

### Layered Architecture
The application is split into layers (presentation, application, domain, infrastructure). Each layer depends only on the one below it.

### Onion Architecture
The domain layer forms the core. Outer rings contain application logic and infrastructure. Dependencies point inward.

### Clean Architecture
Similar to Onion but with explicit rings for entities, use cases, interface adapters, and frameworks. Inner layers know nothing about outer layers.

### Hexagonal Architecture
Also known as Ports and Adapters. The core logic communicates with the outside world through interfaces (ports) that adapters implement.

### Microservices Architecture
The system is decomposed into independently deployable services, each with its own data store. Offers scalability but adds orchestration complexity.

## Repository Pattern
Abstracts data access behind an interface so business logic remains decoupled from how data is stored.

```csharp
public interface ICustomerRepository
{
    Task<Customer> GetByIdAsync(int id);
    Task AddAsync(Customer customer);
}

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    public CustomerRepository(AppDbContext context) => _context = context;

    public Task<Customer> GetByIdAsync(int id) => _context.Customers.FindAsync(id).AsTask();
    public async Task AddAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }
}
```

## Factory Pattern
Encapsulates object creation so calling code is decoupled from specific implementations.

```csharp
public interface IShape { void Draw(); }

public class Circle : IShape { public void Draw() => Console.WriteLine("Circle"); }
public class Square : IShape { public void Draw() => Console.WriteLine("Square"); }

public static class ShapeFactory
{
    public static IShape Create(string type) => type switch
    {
        "circle" => new Circle(),
        "square" => new Square(),
        _ => throw new ArgumentException("Unknown shape")
    };
}
```

## Singleton Pattern
Ensures a class has only one instance and provides global access.

```csharp
public class Logger
{
    private static readonly Logger _instance = new Logger();
    private Logger() { }
    public static Logger Instance => _instance;
    public void Log(string message) => Console.WriteLine(message);
}

Logger.Instance.Log("started");
```

