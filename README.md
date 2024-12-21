# LibraryTemp

LibraryTemp is a simple .NET Core library that serves as a template for other libraries. It includes sample functions for working with placeholders in strings, allowing you to replace placeholders with provided values and validate if all placeholders in a string are satisfied. Additionally, it includes unit tests to ensure the correctness of these functions.

## Features
- Replace placeholders in strings with actual values.
- Validate if all placeholders in a string have corresponding values.
- Designed to be lightweight and easy to integrate into other libraries.
- Includes unit tests for sample functions.

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/emrekardaslar/LibraryTemp.git
   ```

2. Navigate to the project directory:
   ```bash
   cd LibraryTemp
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

4. Add a reference to this library in your project:
   ```bash
   dotnet add reference ../LibraryTemp/LibraryTemp.csproj
   ```

## Usage

### Replace Placeholders
Replace placeholders in a string with actual values using `ReplacePlaceholders`:

```csharp
using LibraryTemp;

var template = "Hello, {{{name}}}! Welcome to {{{place}}}.";
var placeholders = new Dictionary<string, string>
{
    { "name", "Alice" },
    { "place", "Wonderland" }
};