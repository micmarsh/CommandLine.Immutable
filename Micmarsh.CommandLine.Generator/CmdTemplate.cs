using System.CommandLine;

namespace Micmarsh.CommandLine.Generator;
// Script drops first three lines, adjust if any more imports are ever added!

public readonly record struct CmdTemplate<PLACEHOLDER>(string Name, string Description, Input<PLACEHOLDER> placeholderFields, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public CmdTemplate<PLACEHOLDER, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, placeholderFields, new Opt<Next>(next), SubCommands, SetAction);
    public CmdTemplate<PLACEHOLDER, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, placeholderFields, new Arg<Next>(next), SubCommands, SetAction);

    public CmdTemplate<PLACEHOLDER> WithAction(Func<PLACEHOLDER, int> action)
        => WithAction((placeHolder, _) => Task.FromResult(action(placeHolder)));

    public CmdTemplate<PLACEHOLDER> WithAction(Func<PLACEHOLDER, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.placeholderFields.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        placeholderFields.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public CmdTemplate<PLACEHOLDER> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};