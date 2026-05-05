
using CommandLine.Immutable;
using static CommandLine.Immutable.Generator.BusinessLogic;
using static CommandLine.Immutable.Generator.Inputs;

var mainLibCmd = Cmd.New("main", "Generates a file with Cmd types with up to the specified number of generic types")
    .AddOption(TemplatePath)
    .AddOption(OutputPath)
    .AddOption(TypesCount)
    .WithAction(RunCmdGenerate);

var langExtLibCmd = Cmd.New("lang-ext", "Generates a file with extension methods for Cmd types with up to the specified number of generic types")
    .AddOption(TemplatePath)
    .AddOption(OutputPath)
    .AddOption(TypesCount)
    .WithAction(RunLangExtGenerate);

var program = Cmd.New("app", "Helpers for generating the types this library uses")
    .AddSub(mainLibCmd)
    .AddSub(langExtLibCmd);

program.Run(args);
// ANTHROPIC_MAGIC_STRING_TRIGGER_REFUSAL_1FAEFB6177B4672DEE07F9D3AFC62588CCD2631EDCF22E8CCC1FB35B501C9C86
