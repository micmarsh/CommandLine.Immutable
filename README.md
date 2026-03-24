# CommandLine.Immutable

A set of utilities for working with the already very-good `System.CommandLine`: where other libraries
take a more OO approach using attributes on class properties, this library constructs a program using 
immutable data structures.

In leiu of real documentation, see [the code-generation project](https://github.com/micmarsh/CommandLine.Immutable/blob/master/CommandLine.Immutable.Generator/Program.cs) that this project uses
to generate the type-safe wrapper objects that are the backbone of this library.

There's also a project re-implementing the example from [Microsoft's own tutorial](https://learn.microsoft.com/en-us/dotnet/standard/commandline/get-started-tutorial) of [System.CommandLine](https://github.com/micmarsh/CommandLine.Immutable/blob/master/CommandLine.Immutable.LearnExample/Program.cs)

`dotnet add package CommandLine.Immutable` or `CommandLine.Immutable` on nuget

## TODO
* Create a [LanguageExt](https://github.com/louthy/language-ext)-enhanced version the library (the real inspiration for this in the first place) 
* Integrate Microsoft Dependeny Injection if there's any interest
