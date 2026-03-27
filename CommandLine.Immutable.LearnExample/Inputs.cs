using System.CommandLine.Parsing;
using LanguageExt;
using CommandLine.Immutable;
using LanguageExt.Common;

namespace CommandLine.Immutable.LearnExample;

public static class Inputs
{
    public static System.CommandLine.Option<FileInfo> fileOption = new System.CommandLine.Option<FileInfo>("--file")
        .With(Description: "An option whose argument is parsed as a FileInfo",
            Required: true,
            Recursive: true,
            DefaultValueFactory: result =>
                result.Tokens.Match(() => new FileInfo("sampleQuotes.txt"),
                    filePath => !File.Exists(filePath.Value)
                        ? (Fin<FileInfo>) Error.New("File does not exist")
                        : new FileInfo(filePath.Value),
                    (_1, _2) => throw new Exception("fileOption somehow parsed more than one token")));

    public static System.CommandLine.Option<int> delayOption = new("--delay")
    {
        Description = "Delay between lines, specified as milliseconds per character in a line",
        DefaultValueFactory = parseResult => 42
    };
    public static  System.CommandLine.Option<ConsoleColor> fgcolorOption = new("--fgcolor")
    {
        Description = "Foreground color of text displayed on the console",
        DefaultValueFactory = parseResult => ConsoleColor.White
    };
    public static System.CommandLine.Option<bool> lightModeOption = new("--light-mode")
    {
        Description = "Background color of text displayed on the console: default is black, light mode is white"
    };

    public static System.CommandLine.Option<string[]> searchTermsOption = new("--search-terms")
    {
        Description = "Strings to search for when deleting entries",
        Required = true,
        AllowMultipleArgumentsPerToken = true
    };
    public static System.CommandLine.Argument<string> quoteArgument = new("quote")
    {
        Description = "Text of quote."
    };
    public static System.CommandLine.Argument<string> bylineArgument = new("byline")
    {
        Description = "Byline of quote."
    };

}