# OOP

Questions related to object-oriented programming in .NET with real-world examples.

### What is inheritance in C#?
Inheritance allows a class to derive from another, reusing its functionality. For example, `Controller` classes in ASP.NET Core inherit from `ControllerBase` to gain HTTP handling features.

### Describe the difference between an interface and an abstract class.
An interface defines a contract with no implementation, while an abstract class can provide some default implementation. Interfaces allow multiple inheritance of type, whereas classes do not.

### What is encapsulation and why is it important?
Encapsulation hides the internal state of an object and exposes behavior through methods or properties. This protects invariants and simplifies usage of the object.

### Explain polymorphism with an example.
Polymorphism lets you treat instances of different classes through a common interface or base class. A `List<Shape>` can contain `Circle` and `Rectangle` objects, each overriding a virtual `Draw` method.

### What are the four pillars of OOP?
Encapsulation, inheritance, polymorphism, and abstraction form the fundamental concepts of object-oriented programming.

### What is abstraction?
Abstraction focuses on exposing only essential features while hiding implementation details. An abstract base class can define abstract methods that derived classes implement.

### When would you prefer composition over inheritance?
Composition is favored when you want to combine behaviors without creating deep inheritance hierarchies. For example, a `Logger` service can be injected into multiple classes instead of inheriting from a common logging base class.

## Static in C#

### What is a static class in C#? Can you create an object of a static class?
A static class cannot be instantiated and is intended only for grouping static members. You cannot create an object of it because all functionality is accessed through the type itself.

### What is the difference between static and instance members?
Static members belong to the type and are shared across all objects, whereas instance members exist separately for each object.

### What is a static constructor? When does it get called?
A static constructor initializes static data for a type. It runs once automatically before the type is first used.

### Can a static method access instance members? Why or why not?
No. Static methods do not operate on a particular object instance so they cannot access instance fields or properties directly.

### What is the use of the static keyword in C#? Provide examples.
`static` indicates that a member or class belongs to the type itself. Examples include `Math.Pow` or a static `Instance` property in a singleton class.

## Constructors in C#

### What is the purpose of a constructor in C#?
It initializes a new instance of a class and sets up its initial state.

### How do you define a parameterized constructor?
Provide parameters in the constructor signature so callers supply values during object creation.

### What is a default constructor?
A parameterless constructor automatically supplied by the compiler if none is defined.

### Explain the difference between instance constructors and static constructors.
Instance constructors run whenever an object is created. Static constructors run once to set up static data for the type.

### Can you overload constructors in C#? How?
Yes. Define multiple constructors with different parameter lists to provide various initialization options.

### What happens if you don’t define a constructor for a class?
The compiler adds a parameterless constructor that performs default initialization.

### What is a copy constructor? Does C# support it?
A copy constructor creates a new object based on another object's state. C# does not provide one automatically but you can implement it manually.

### Can a constructor be private? Give an example use case.
Yes. Private constructors are used to restrict instantiation, such as in the singleton pattern.

## Abstract Classes and Interfaces

### What is the difference between an abstract class and an interface in C#?
An abstract class can include implementation and fields, while an interface only defines members that implementing classes must provide.

### Can an abstract class have constructors? Why?
Yes. Abstract classes can have constructors to initialize common state for derived classes.

### Can an abstract class have implemented methods?
It can contain both abstract methods and fully implemented methods that derived classes may use or override.

### Can you create an object of an abstract class?
No. Abstract classes cannot be instantiated directly; you must use a derived concrete class.

### What happens if you don’t implement all members of an interface in a class?
The class must be declared abstract, otherwise the compiler will produce an error.

### Can a class implement multiple interfaces? Can it inherit from multiple abstract classes?
A class can implement any number of interfaces but may inherit from only one abstract or concrete base class.

### How do you explicitly implement an interface in C#?
Prefix the member name with the interface name, for example `void ILogger.Log() { ... }`, so it is accessible only through the interface type.

## Object Class in C#

### What is the base class of all classes in C#?
`System.Object` is the root type from which every class ultimately derives.

### List some important methods of the object class.
`Equals`, `GetHashCode`, `ToString`, and `GetType` are commonly overridden methods.

### What is the purpose of the Equals() method? How is it different from ==?
`Equals` checks for value equality. `==` may be overloaded; for reference types it checks reference equality by default.

### What does the GetHashCode() method do?
It returns an integer hash used when storing objects in hash-based collections like dictionaries.

### What is the ToString() method? How would you override it?
`ToString` provides a textual representation of an object. Override it to return meaningful information about the instance.

## String Immutability

### What does it mean when we say a string in C# is immutable?
Once created, the characters in a string cannot be changed.

### Why are strings immutable in C#?
Immutability ensures thread safety and enables string interning optimizations.

### What happens when you modify a string in C#?
A new string object is created; the original instance remains unchanged.

### What is the difference between StringBuilder and string? When would you use one over the other?
`StringBuilder` is mutable and efficient for repeated concatenation, while `string` is best for small or infrequent modifications.

### How does string interning work in C#?
The runtime stores one instance of each unique string literal so identical strings share the same memory.

## Interfaces and Multiple Interfaces

### What is an interface in C#? How is it different from an abstract class?
An interface defines a set of members without implementation, whereas an abstract class can provide both members and implementation.

### Can you have fields in an interface? Why or why not?
No. Interfaces cannot declare fields because they represent behavior only, not state.

### Can an interface inherit from another interface?
Yes. Interfaces can extend one or more other interfaces.

### Can a class implement multiple interfaces? Give an example.
Yes. `public class Repository : IRead, IWrite { }` shows a class implementing two interfaces.

### How do you resolve naming conflicts when two interfaces have methods with the same name?
Use explicit interface implementation to provide separate implementations.

### What is explicit interface implementation? Why would you use it?
It hides the member so it is accessible only through the interface, useful when method names conflict or to avoid exposing members publicly.

### How would you call a method from an interface when it’s explicitly implemented?
Cast the object to the interface type before invoking the method.

### How can you access an interface method if a class implements multiple interfaces with the same method signature?
Cast the object to the specific interface that defines the desired method.

## Difficult/Advanced OOPs Questions in C#

### What is the difference between early binding and late binding? Provide examples.
Early binding resolves method calls at compile time using static types. Late binding resolves at runtime through reflection or dynamic typing.

### Explain the difference between override and new keyword in method overriding.
`override` extends a base virtual method, while `new` hides the base method with a separate implementation.

### How does method hiding work? What’s the difference between method hiding and method overriding?
Method hiding replaces a base member when accessed through the derived type. Overriding enables polymorphism when accessed via a base reference.

### Can you override a non-virtual method? Why not?
No. Only methods marked virtual, abstract, or override can be overridden.

### What is covariance and contravariance in C#? Provide examples.
They allow assignment compatibility for generic type parameters in delegates and interfaces, enabling more or less derived types.

### Explain the concept of Liskov Substitution Principle with an example.
Objects of a derived class should be usable in place of the base class without altering correct behavior, e.g., using a `Stream` where a `FileStream` is expected.

### What is the difference between shallow copy and deep copy? How do you implement deep cloning?
Shallow copy duplicates references while deep copy duplicates all nested objects. Implement deep cloning manually or via serialization.

### How does C# implement runtime polymorphism?
Through virtual methods and interfaces, where the runtime dispatches calls to the most derived implementation.

### Explain the difference between is, as, and casting in C#.
`is` checks if an object is of a given type, `as` performs a safe cast returning null if it fails, and a direct cast throws an exception if incompatible.

### What is the diamond problem in multiple inheritance? How does C# avoid it with interfaces?
Multiple class inheritance can cause ambiguity when two base classes define the same member. C# allows multiple interface inheritance but only single class inheritance to avoid this issue.

### Can a class implement an interface explicitly and also provide a public implementation for the same method?
Yes. A class can expose a public method and separately implement the interface member explicitly to keep interface-specific behavior.

