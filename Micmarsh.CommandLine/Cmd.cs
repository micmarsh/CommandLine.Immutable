using System.CommandLine;
using Micmarsh.CommandLine.Generator;

namespace Micmarsh.CommandLine;


public class Cmd(string Name, string Description, IEnumerable<Command> SubCommands)
{
    public static Cmd New(string name, string desc) => new Cmd(name, desc,[]);
    
    public Cmd<A> AddOption<A>(Option<A> option) => new (Name, Description, new Opt<A>(option), []);
    public Cmd<A> AddArgument<A>(Argument<A> option) => new (Name, Description, new Arg<A>(option), []);
    
    public Command SetAction(Func<int> action)
        => SetAction(_ => Task.FromResult(action()));
    
    public Command SetAction(Func<CancellationToken, Task<int>> action)
    {
        var result = ToCommand();
        result.SetAction((_, ct) => action(ct));
        return result;
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }

}

public static class CommandExt
{
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