using System.CommandLine;

namespace Micmarsh.CommandLine;

public record RootCmd(IEnumerable<Command> SubCommands)
{
    /// <summary>
    /// Remember to call <see cref="Cmd.AsRoot"/> at end of method chain if adding options to RootCmd
    /// </summary>
    public static Cmd<A> AddOption<A>(Option<A> option) => new (option, []);

    public RootCommand SetDescription(string description = "")
    {
        var result = new RootCommand(description);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public RootCmd AddSub(Command cmd) => new(SubCommands.Append(cmd));
}