# String Reversal Service

This project provides a simple string reversal application along with unit tests to ensure its functionality.

## Purpose

The String Reversal Service is designed to reverse strings provided by the user. It includes a main application that implements the string reversal logic and a set of unit tests to validate the correctness of the implementation.

## Project Structure

```
StringReversalService
├── StringReversalApp
│   ├── StringReversalApp.csproj
│   └── StringReverser.cs
├── StringReversalApp.Tests
│   ├── StringReversalApp.Tests.csproj
│   └── StringReverserTests.cs
└── StringReversalService.sln
```

## Setup Instructions

1. Clone the repository to your local machine.
2. Navigate to the `StringReversalService` directory.
3. Restore the project dependencies by running:
   ```
   dotnet restore
   ```
4. Build the solution using:
   ```
   dotnet build
   ```

## Usage

To use the string reversal functionality, you can call the `Reverse` method from the `StringReverser` class in the `StringReversalApp` project. 

## Running Tests

To run the unit tests, navigate to the `StringReversalApp.Tests` directory and execute:
```
dotnet test
```

This will run all the tests defined in the `StringReverserTests` class and provide feedback on the success or failure of each test.