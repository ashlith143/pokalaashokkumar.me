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
