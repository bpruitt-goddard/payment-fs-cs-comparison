# Purpose
To demonstrate the difference between functional (.net 6) C# and F#.

The application is a very simple payment processing service that logs payments made by either cash or credit card with basic validation. The service shows a few features/differences between C# and F#:
1. Discriminated Unions - these are currently built-in to F#, with only [proposed support](https://github.com/dotnet/csharplang/blob/main/proposals/discriminated-unions.md) in C#. There are C# libraries that make use of them such as [OneOf](https://github.com/mcintyre321/OneOf/), but the support is not yet native.
2. Option/Value Options - these are built-in to F#, but not C#. This allows for simpler/more readable payment processing.
3. Whitespace/curly brackets - A big reason for the shorter F# code is the whitespace awareness, that avoids extra lines dedicated to curly brackets.
4. Ease of calling F# from C#. As long as the F# interface deals with supported C# features, it is very simple to add an F# project to a C# solution. Where it gets tricky is in using unsupported C# features, such as F#'s value options - see the InvalidCashReturnsError test.

# Running
The project is structured so that the external interface for both the C# and F# service are identical. This is then validated via the unit tests in the C# test project - this project runs both solutions and validates the results are equivalent. A simple `dotnet test` will run the test project.