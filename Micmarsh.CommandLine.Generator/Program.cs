
using System.CommandLine;
using Micmarsh.CommandLine;

const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

var uppercase = letters.ToUpper().ToArray();
var lowercase = letters.ToLower().ToArray();


Option<FileInfo> templatePath = new("--template", "-t")
{
    Description = "The template file location"
};

Option<FileInfo> outputPath = new("--output", "-o")
{
    Description = "Where to save the output"
};

Option<uint> typesCount = new("--number", "-n")
{
    Description = "Max number of of generic types to generate (max 26)",
    DefaultValueFactory = _ => 5,
    Required = false
};
var program = Cmd
    .AddOption(templatePath)
    .AddOption(outputPath)
    .AddOption(typesCount)
    .SetAction("app", "Generates a file with Cmd types with up to the specified number of generic types",
        (input, output, countInput) =>
        {
            var count = Math.Min((int)countInput, letters.Length);
            var fullInputFile = File.ReadAllLines(input.FullName);
            var typeTemplate = string.Join(Environment.NewLine, fullInputFile.Skip(4));
            var generatedTypes = Enumerable.Range(1, count).Select(num => GenerateType(typeTemplate, num));
            File.WriteAllText(output.FullName, string.Join(Environment.NewLine, 
                generatedTypes.Prepend(Environment.NewLine)
                    .Prepend(fullInputFile[2])
                    .Prepend(fullInputFile[1])
                    .Prepend(fullInputFile[0])));
            return 0;
        })
    .AsRoot();

program.Parse(args).Invoke();

string GenerateType(string template, int num)
{
    var fieldsInConst = Enumerable.Range(0, num)
        .Select(i => $"Input<{uppercase[i]}> input{i}");
    var typeParams = Enumerable.Range(0, num).Select(i => uppercase[i]);
    
    var valueLookups = Enumerable.Range(0, num)
        .Select(i => $"self.input{i}.GetValue(parseResult)");
    var inputAdds = Enumerable.Range(0, num)
        .Select(i => $"input{i}.AddTo(result);");
    
    var fields = Enumerable.Range(0, num).Select(i => $"input{i}");
    var parsedVars = Enumerable.Range(0, num).Select(i => lowercase[i]);

    return template
        .Replace("CmdTemplate", "Cmd")
        .Replace("Input<PLACEHOLDER> placeholderFields", string.Join(", ", fieldsInConst))
        .Replace("PLACEHOLDER", string.Join(", ", typeParams))
        .Replace("self.placeholderFields.GetValue(parseResult)", string.Join($",{Environment.NewLine}\t\t\t\t\t", valueLookups))
        .Replace("placeholderFields.AddTo(result);", string.Join($"{Environment.NewLine}\t\t", inputAdds))
        .Replace("placeholderFields", string.Join(", ", fields))
        .Replace("placeHolder", string.Join(", ", parsedVars));
}