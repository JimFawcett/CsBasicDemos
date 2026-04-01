# CsBasicDemos

Reference: https://JimFawcett.github.io/CsBasicDemos.html

A collection of standalone C# demos illustrating language syntax, collections, delegates, reflection, threading, and more. Each project builds and runs independently.

## Building and Running

**SDK-style projects** (net8.0, `<Project Sdk=...>`):
```
dotnet run --project <path-to-csproj>
```

**Legacy projects** (older `.csproj` with `ToolsVersion`): require Visual Studio or MSBuild with the full .NET Framework.

## Projects

| Directory | Concept | Description |
|---|---|---|
| `Collections/` | .NET Collections | Multi-module program using arrays, `SortedList`, `Hashtable`, and `List<T>` |
| `Conversions/` | Type Conversions | String-to-type and type-to-type conversions via `ToString()`, `Parse()`, and `Convert` |
| `CSharpDemos/` | Basic Classes | Class definitions, encapsulation, properties, constructors, and object identity |
| `CSharpExamples/` | Arrays | Single and multi-dimensional array creation, iteration, and manipulation |
| `CSharpSyntax/` | Equivalence Testing | Four equivalence tests: `ReferenceEquals`, static `Equals`, instance `Equals`, `operator==` |
| `CsReflection/` | Reflection | Extracts assembly metadata, modules, types, and file info using `System.Reflection` |
| `Delegates-using/` | Delegates | Traditional delegates, anonymous delegates, lambda expressions, and `Func<T>` |
| `DynamicLinkLibraries/` | Dynamic Loading | Implicit and explicit DLL loading via reflection and interfaces |
| `ExtensionMethods/` | Extension Methods | Adds custom methods to existing types (`Object`, `IEnumerable`) via extension syntax |
| `LambdaCapture/` | Lambda Closures | Lambda expressions capturing local variables and transporting scope for deferred execution |
| `LambdaDemo/` | Delegates & Lambdas | Delegate internals, lambda expressions, and reflection to inspect lambda type details |
| `LinqExamples/` | LINQ to XML | LINQ queries on `XDocument` with WPF data binding to collections |
| `LinqQueryExamples/` | LINQ Query Syntax | LINQ to Objects — query syntax, method chaining, filtering, ordering, and projection |
| `MethodParamDemo/` | Method Parameters | By-value vs. by-reference parameter passing for value types and reference types |
| `NetContainers/` | Generic Collections | `ArrayList` capacity management, sorting, searching, and insertion/removal |
| `TestDeserialization/` | Serialization | Serializable `Message` class with XML parsing for building and parsing messages |
| `ThreadsAndTasks/` | Threads | Thread creation with parameters, lambda capture in threads, and concurrent execution |
| `ThreadTechniques/` | Thread Synchronization | `BlockingQueue` using monitors and locks for thread-safe producer/consumer communication |

## Notes

- `Backup/`, `Backup1/`, `Backup2/` subdirectories within each project are historical snapshots — edit only the non-Backup copies.
- All demos use `Main()` as the entry point and harness; output is printed to the console.
- `LinqExamples` contains WPF components and requires Windows.
