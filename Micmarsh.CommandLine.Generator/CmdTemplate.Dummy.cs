using System.CommandLine;

namespace Micmarsh.CommandLine.Generator;

public record CmdTemplate<A, B>(
    string name, 
    string desc,
    Input<A> a,
    Input<B> b,
    IEnumerable<Command> SubCommands);
