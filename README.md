# CommandLine.Immutable

A set of utilities for working with the already very-good `System.CommandLine`: where other libraries
take a more OO approach using attributes on class properties, this library constructs a program using 
immutable data structures.

In leiu of real documentation, see [the code-generation project]() that this project uses
to generate the type-safe wrapper objects that are the backbone of this library.


## TODO
* Real documentation/examples
  * Re-implementing https://learn.microsoft.com/en-us/dotnet/standard/commandline/get-started-tutorial using this library is likely the best way to go about this
* Create a [LanguageExt](https://github.com/louthy/language-ext)-enhanced version the library (the real inspiration for this in the first place) 
* Integrate Microsoft Dependeny Injection if there's any interest
