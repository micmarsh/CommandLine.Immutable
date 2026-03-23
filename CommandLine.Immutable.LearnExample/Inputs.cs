using System.CommandLine;

namespace CommandLine.Immutable.LearnExample;

public static class Inputs
{
    public static Option<FileInfo> fileOption = new("--file")
    {
        Description = "An option whose argument is parsed as a FileInfo",
        Required = true,
        DefaultValueFactory = result =>
        {
            if (result.Tokens.Count == 0)
            {
                return new FileInfo("sampleQuotes.txt");

            }
            string filePath = result.Tokens.Single().Value;
            if (!File.Exists(filePath))
            {
                result.AddError("File does not exist");
                return null;
            }
            else
            {
                return new FileInfo(filePath);
            }
        },
        Recursive = true
    };

    public static Option<int> delayOption = new("--delay")
    {
        Description = "Delay between lines, specified as milliseconds per character in a line",
        DefaultValueFactory = parseResult => 42
    };
    public static  Option<ConsoleColor> fgcolorOption = new("--fgcolor")
    {
        Description = "Foreground color of text displayed on the console",
        DefaultValueFactory = parseResult => ConsoleColor.White
    };
    public static Option<bool> lightModeOption = new("--light-mode")
    {
        Description = "Background color of text displayed on the console: default is black, light mode is white"
    };

    public static Option<string[]> searchTermsOption = new("--search-terms")
    {
        Description = "Strings to search for when deleting entries",
        Required = true,
        AllowMultipleArgumentsPerToken = true
    };
    public static Argument<string> quoteArgument = new("quote")
    {
        Description = "Text of quote."
    };
    public static Argument<string> bylineArgument = new("byline")
    {
        Description = "Byline of quote."
    };

}