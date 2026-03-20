using System.CommandLine;

namespace Micmarsh.CommandLine.Generator;
// Script drops first three lines, adjust if any more imports are ever added!

public readonly record struct CmdTemplate<PLACEHOLDER>(Input<PLACEHOLDER> placeholderFields, IEnumerable<Command> SubCommands)
{
    public CmdTemplate<PLACEHOLDER, Next> AddOption<Next>(Option<Next> next) => 
        new(placeholderFields, new Opt<Next>(next), SubCommands);
    
    public CmdTemplate<PLACEHOLDER, Next> AddArgument<Next>(Argument<Next> next) => 
        new(placeholderFields, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<PLACEHOLDER, int> action)
        => SetAction(name, description, (placeHolder, _) => Task.FromResult(action(placeHolder)));
    
    public Command SetAction(string name, string description, Func<PLACEHOLDER, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        placeholderFields.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.placeholderFields.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public CmdTemplate<PLACEHOLDER> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};