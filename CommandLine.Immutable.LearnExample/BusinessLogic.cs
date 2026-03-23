namespace CommandLine.Immutable.LearnExample;

public static class BusinessLogic
{
    public static int ReadFile(FileInfo file, int delay, ConsoleColor fgColor, bool lightMode)
    {
        Console.BackgroundColor = lightMode ? ConsoleColor.White : ConsoleColor.Black;
        Console.ForegroundColor = fgColor;
        foreach (string line in File.ReadLines(file.FullName))
        {
            Console.WriteLine(line);
            Thread.Sleep(TimeSpan.FromMilliseconds(delay * line.Length));
        }
        //todo maybe lib should handle Actions and not force this to return?
        return 0;
    }
    public static int DeleteFromFile(FileInfo file, string[] searchTerms)
    {
        Console.WriteLine("Deleting from file");

        var lines = File.ReadLines(file.FullName).Where(line => searchTerms.All(s => !line.Contains(s)));
        File.WriteAllLines(file.FullName, lines);
        return 0;
    }
    public static int AddToFile(FileInfo file, string quote, string byline)
    {
        Console.WriteLine("Adding to file");

        using StreamWriter writer = file.AppendText();
        writer.WriteLine($"{Environment.NewLine}{Environment.NewLine}{quote}");
        writer.WriteLine($"{Environment.NewLine}-{byline}");
        return 0;
    }

}