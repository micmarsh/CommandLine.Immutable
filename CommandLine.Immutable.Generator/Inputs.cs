using System.CommandLine;

namespace CommandLine.Immutable.Generator;

public static class Inputs
{
    
    public static Option<FileInfo> TemplatePath = new("--template", "-t")
    {
        Description = "The template file location"
    };

    public static Option<LanguageExt.Option<FileInfo>> OutputPath = OptionalInput.Opt<FileInfo>("--output", "-o")
        .With(Description: "Where to save the output, program will utlize stdout if this isn't provided");

    public static Option<uint> TypesCount = new("--number", "-n")
    {
        Description = "Number of of generic types to generate (max 26)",
        DefaultValueFactory = _ => 5,
        Required = false
    };
}