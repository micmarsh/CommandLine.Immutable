using System.CommandLine;

namespace Micmarsh.CommandLine.Generator;
// Script drops first three lines, adjust if any more imports are ever added!

public readonly record struct CmdTemplate<PLACEHOLDER>(string Name, string Description, Input<PLACEHOLDER> placeholderFields, IEnumerable<Command> SubCommands)
{
    public CmdTemplate<PLACEHOLDER, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, placeholderFields, new Opt<Next>(next), SubCommands);
    public CmdTemplate<PLACEHOLDER, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, placeholderFields, new Arg<Next>(next), SubCommands);

    public Command SetAction(Func<PLACEHOLDER, int> action)
        => SetAction((placeHolder, _) => Task.FromResult(action(placeHolder)));
    
    public Command SetAction(Func<PLACEHOLDER, CancellationToken, Task<int>> action)
    {
        var result = ToCommand();
        var self = this;
        result.SetAction((parseResult, ct) => action(self.placeholderFields.GetValue(parseResult), ct));
        return result;
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        placeholderFields.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }

    public CmdTemplate<PLACEHOLDER> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};