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
