---
applyTo: "**/*.cs"
---

# Code Style Instructions

When writing C# code in this repository, strictly follow these conventions:

## Required Language Features

- Use file-scoped namespaces (REQUIRED): `namespace Project.Module;`
- Use primary constructors with dependency injection (REQUIRED for classes with dependencies)
- Target framework: net10.0
- Language version: preview (cutting-edge C# features)
- ImplicitUsings: enabled

## Null Safety Requirements

All parameters MUST be validated for null:

```csharp
// For method parameters
public string ValueFor(string key)
{
    ArgumentNullException.ThrowIfNull(key);
    // Method implementation
}

// For constructor parameters with primary constructors
// Use [NotNull] from JetBrains.Annotations
public class AppSettingByKey(
    [NotNull] IAppSettingsFromJsonFile appSettingsFromJsonFile) : IAppSettingByKey
{
    private readonly IAppSettingsFromJsonFile _appSettingsFromJsonFile = 
        appSettingsFromJsonFile ?? throw new ArgumentNullException(nameof(appSettingsFromJsonFile));
}
```

## Documentation & Comments

- Use `/// <inheritdoc />` for all members implementing an interface or overriding a base member.
- For classes, include XML documentation for the constructor:
  ```csharp
  /// <inheritdoc />
  /// <summary>
  ///     Constructor
  /// </summary>
  /// <param name="dependency"></param>
  public class MyClass([NotNull] IDependency dependency) : IMyClass
  {
      private readonly IDependency _dependency = dependency ?? throw new ArgumentNullException(nameof(dependency));
  }
  ```
- Respect ReSharper suppression comments if they exist in the file (e.g., `// ReSharper disable ...`).

## Global Usings Available

These usings are available globally (via `Directory.Build.props`):
- `EvilBaschdi.Core`
- `JetBrains.Annotations`

Conditional Global Usings:
- `.DependencyInjection` projects: `Microsoft.Extensions.Hosting`, `Microsoft.Extensions.DependencyInjection`
- `.Settings` projects: `Microsoft.Extensions.Configuration.Binder`, `Microsoft.Extensions.Configuration.FileExtensions`, `Microsoft.Extensions.Configuration.Json`
- `.Tests` projects: `AutoFixture.Idioms`, `AutoFixture.Xunit3`, `EvilBaschdi.Testing`, `FluentAssertions`, `NSubstitute`, `Xunit`, etc.

## Naming Conventions

- Private fields: `_fieldName` (underscore prefix, camelCase)
- Public properties/methods: `PropertyName` / `MethodName` (PascalCase)
- Local variables: `variableName` (camelCase)
- Classes follow their interface: `IMyInterface` → `MyInterface`

## Testing Standards

- Use XUnit v3 with NSubstitute and AutoFixture.
- Use `[Theory, NSubstituteOmitAutoPropertiesTrueAutoData]` for data-driven tests.
- Verify constructor and method null guards using `GuardClauseAssertion`.
- Use FluentAssertions for assertions (e.g., `sut.Should().BeAssignableTo<IInterface>();`).