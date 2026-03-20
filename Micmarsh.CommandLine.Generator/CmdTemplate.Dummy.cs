using System.CommandLine;

namespace Micmarsh.CommandLine.Generator;

public record CmdTemplate<A, B>(
    Input<A> a,
    Input<B> b,
    IEnumerable<Command> SubCommands);
