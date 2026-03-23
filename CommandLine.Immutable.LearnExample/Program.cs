using System.CommandLine;
using CommandLine.Immutable;
using static CommandLine.Immutable.LearnExample.Inputs;
using static CommandLine.Immutable.LearnExample.BusinessLogic;

var readCmd = Cmd.New("read", "Read and display the file.")
    .AddOption(fileOption)//todo look into this! Subcommands have access to parent args! This can handle just fine?
    .AddOption(delayOption)
    .AddOption(fgcolorOption)
    .AddOption(lightModeOption)
    .WithAction(ReadFile);

var deleteCmd = Cmd.New("delete", "Delete lines from the file.")
    .AddOption(fileOption)
    .AddOption(searchTermsOption)
    .WithAction(DeleteFromFile);

var addCommand = Cmd.New("add", "Add an entry to the file.")
    .AddOption(fileOption)
    .AddArgument(quoteArgument)
    .AddArgument(bylineArgument)
    .WithAction(AddToFile)
    .ToCommand();
// Aliases not covered by library!
addCommand.Aliases.Add("insert");

Cmd.New("root", "Sample app for System.CommandLine")
    .AddOption(fileOption)
    .AddSub(Cmd.New("quotes", "Work with a file that contains quotes.")
        .AddSub(readCmd)
        .AddSub(deleteCmd)
        .AddSub(addCommand))
    .ToRoot()
    .Parse(args).Invoke();