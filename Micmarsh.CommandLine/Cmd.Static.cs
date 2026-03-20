using System.CommandLine;

namespace Micmarsh.CommandLine;


public static class Cmd
{
    public static Cmd<A> AddOption<A>(Option<A> option) => new (option, []);
    
    public static RootCmd AddSub(Command cmd) => new ([cmd]);

    public static RootCommand AsRoot(this Command command)
    {
        var root =  new RootCommand(command.Description ?? string.Empty);
        foreach (var opt in command.Options) root.Options.Add(opt);
        foreach (var arg in command.Arguments) root.Arguments.Add(arg);
        foreach (var sub in command.Subcommands) root.Subcommands.Add(sub);
        //todo arguments and other things?
        return root;
    }
}