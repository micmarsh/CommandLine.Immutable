using System.CommandLine;
using CommandLine.Immutable.Generator;

namespace CommandLine.Immutable;


public readonly record struct Cmd(string Name, string Description, IEnumerable<ICmd> SubCommands, Action<Command>? SetAction) : ICmd
{
    public static Cmd New(string name, string desc) => new Cmd(name, desc,[], null);
    
    public Cmd<A> AddOption<A>(Option<A> option) => new (Name, Description, new Opt<A>(option), SubCommands, SetAction);
    public Cmd<A> AddArgument<A>(Argument<A> option) => new (Name, Description, new Arg<A>(option), SubCommands, SetAction);
    
    public Cmd WithAction(Func<int> action) => WithAction(_ => Task.FromResult(action()));
    
    public Cmd WithAction(Func<CancellationToken, Task<int>> action) =>
        this with
        {
            SetAction = command => command.SetAction((_, ct) => action(ct))
        };

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd.ToCommand());
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd AddSub(ICmd cmd) => this with {SubCommands = SubCommands.Append(cmd)};
    
    public Cmd AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(new PureWrapper(cmd))};

}

public interface ICmd
{
    Command ToCommand();
}

public record PureWrapper(Command command) : ICmd
{
    public Command ToCommand() => command;
}

public static class CommandExt
{
    public static RootCommand ToRoot(this ICmd command) => command.ToCommand().ToRoot();

    public static RootCommand ToRoot(this Command command)
    {
        var root =  new RootCommand(command.Description ?? string.Empty);
        foreach (var opt in command.Options) root.Options.Add(opt);
        foreach (var arg in command.Arguments) root.Arguments.Add(arg);
        foreach (var sub in command.Subcommands) root.Subcommands.Add(sub);
        root.Action = command.Action;
        return root;
    }
}