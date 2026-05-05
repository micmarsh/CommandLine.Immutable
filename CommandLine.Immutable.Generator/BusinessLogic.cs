namespace CommandLine.Immutable.Generator;
using static LanguageExt.Prelude;

public static class BusinessLogic
{
    
    const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    static readonly string lowercase = uppercase.ToLower();


    const string LangExtExtMethods = "PLACEHOLDER_METHODS";

    static readonly string LangExtFile = $@"
    using System.CommandLine;
    using LanguageExt;
    namespace CommandLine.Immutable;

    public static class CmdExtensions
    {{
        {LangExtExtMethods}
    }}
    ";
        
    public static int RunLangExtGenerate(FileInfo input, LanguageExt.Option<FileInfo> output, uint numTypes)
    {
        var count = Math.Min((int)numTypes, uppercase.Length);
        var fullInputFile = File.ReadAllLines(input.FullName);
        
        var template = string.Join(Environment.NewLine, fullInputFile.Skip(7).SkipLast(1));
        
        var generated = Enumerable.Range(1, count).Select(num => GenerateType(template, "cmd", num));
        
        var fullOutput = LangExtFile.Replace(LangExtExtMethods, string.Join(Environment.NewLine, generated));
        
        output.Match(fileInfo => File.WriteAllText(fileInfo.FullName, fullOutput),
            () => Console.WriteLine(fullOutput));
        return 0;
    }

    public static int RunCmdGenerate(FileInfo input, LanguageExt.Option<FileInfo> output, uint numTypes)
    {
        var count = Math.Min((int)numTypes, uppercase.Length);
        var fullInputFile = File.ReadAllLines(input.FullName);
        
        var template = string.Join(Environment.NewLine, fullInputFile.Skip(4));
        
        var generated = Enumerable.Range(1, count).Select(num => GenerateType(template, "self", num));
        
        var fullOutput = string.Join(Environment.NewLine, 
            generated.Prepend("namespace CommandLine.Immutable;")
                .Prepend(fullInputFile[1])
                .Prepend(fullInputFile[0]));
        
        output.Match(fileInfo => File.WriteAllText(fileInfo.FullName, fullOutput),
            () => Console.WriteLine(fullOutput));
        return 0;
    }

    static string GenerateType(string template, string selfVar, int num)
    {
        var typeParams = toSeq(uppercase.Take(num));
        var fields = typeParams.Select(type => $"input{type}");

        var fieldsInConst = typeParams.Zip(fields)
            .Select(pair => $"Input<{pair.First}> {pair.Second}");

        var valueLookups = fields
            .Select(field => $"{selfVar}.{field}.GetValue(parseResult)");
        var inputAdds = fields
            .Select(field => $"{field}.AddTo(result);");

        var parsedVars = lowercase.Take(fields.Count());

        return template
            .Replace("CmdTemplate", "Cmd")
            .Replace("Input<PLACEHOLDER> placeholderFields", string.Join(", ", fieldsInConst))
            .Replace("PLACEHOLDER", string.Join(", ", typeParams))
            .Replace($"{selfVar}.placeholderFields.GetValue(parseResult)", string.Join($",{Environment.NewLine}\t\t\t\t\t", valueLookups))
            .Replace("placeholderFields.AddTo(result);", string.Join($"{Environment.NewLine}\t\t", inputAdds))
            .Replace("placeholderFields", string.Join(", ", fields))
            .Replace("placeHolder", string.Join(", ", parsedVars));
    }
}